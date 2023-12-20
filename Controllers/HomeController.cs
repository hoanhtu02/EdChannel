using EdChannel.Data;
using EdChannel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace EdChannel.Controllers
{
    //[Authorize(Roles = "Admin,User,Member")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public long GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return long.Parse(userId);
        }

        public long GetCartId(long userId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.Status != CartStatus.Abandoned);
            if (cart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                return newCart.Id;
            }
            return cart.Id;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CartId = GetCartId(GetUserId());
            }
            else
            {
                ViewBag.CartId = null;
            }
            ViewBag.Categories = _context.Categories.Where(cat => cat.ParentId == null).ToList();
            ViewBag.SubCategories = _context.Categories.Where(cat => cat.ParentId != null).ToList(); 
            ViewBag.NewArrivals = _context.Products.OrderByDescending(p => p.CreatedAt).Take(10).ToList();
            ViewBag.Products = _context.Products.ToList();
            ViewBag.PreviewProducts = _context.Products.Take(8).ToList();
            

            var bestSeller = _context.OrderItems.Join(_context.Products, oi => oi.ProductId, p => p.Id, (oi, p) => new { p, oi })
                .GroupBy(x => x.p)
                .Select(g => new { Product = g.Key, Total = g.Sum(x => x.oi.Quantity) })
                .OrderByDescending(x => x.Total)
                .Take(8)
                .ToList();
            // get list of product by in best seller
            var listBestSeller = new List<Product>();
            foreach (var item in bestSeller)
            {
                listBestSeller.Add(item.Product);
            }
            ViewBag.BestSellers = listBestSeller;

            //ViewBag.BestSellers = _context.OrderItems.Join(_context.Products, oi=>oi.ProductId, p=>p.Id, (oi,p)=> new {  });
            return View();
        }
        [Authorize(Roles = "Admin,User,Member")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User,Member")]
        [HttpGet]
        public IActionResult MyProfileDirect()
        {

            ViewBag.CartId = GetCartId(GetUserId());
            ApplicationUser currUserLoggedIn = _userManager.GetUserAsync(User).Result;
            ViewBag.ListOrder = _context.Orders.Where(o => o.UserId == currUserLoggedIn.Id).ToList();
            return View(currUserLoggedIn);
        }

        public IActionResult About()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            return View();
        }
        [HttpGet]
        [Route("/blog")]
        public IActionResult Blog()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var blog = _context.Blogs.Include(b=>b.Category).ToList();
            // 5 lasted blog
            var lasteBlog = _context.Blogs.Include(_b => _b.Category).OrderBy(p=>p.CreatedAt).Take(4).ToList();
            ViewBag.lasteBlog = lasteBlog;
            ViewBag.IsSingle = false;
            return View(blog);
        }
        [HttpGet]
        [Route("/carts")]
        [Authorize(Roles = "Admin,User,Member")]
        public IActionResult Cart()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var cart = _context.Carts.Find(GetCartId(GetUserId()));
            var cartItems = _context.CartItems.Where(c => c.CartId == cart.Id).Include(c => c.Product).ToList();
            return View(cartItems);
        }
        [HttpGet]
        [Route("/checkout")]
        [Authorize(Roles = "Admin,User,Member")]
        public IActionResult CheckOut()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var cart = _context.Carts.Find(GetCartId(GetUserId()));
            var cartItems = _context.CartItems.Where(c => c.CartId == cart.Id).Include(c => c.Product).ToList();
            return View(cartItems);
        }
        [HttpGet]
        [Route("/blog/{slug}")]
        public IActionResult Blog(string slug)
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var blog = _context.Blogs.Include(b => b.Category).ToList();
            ViewBag.blog = _context.Blogs.FirstOrDefault(b=>b.Slug == slug);
            ViewBag.IsSingle = true;
            return View(blog);
        }
        [Route("categories")]
        [Authorize(Roles = "Admin,User,Member")]
        public IActionResult Category()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var products = _context.Products.Include(p=>p.ProductCategories).ToList();
            ViewBag.Categories = _context.Categories.Where(s => s.ParentId == null).ToList();
            ViewBag.SubCategories = _context.Categories.Where(s=>s.ParentId!=null).ToList();
            return View(products);
        }

        [Route("products/{id}")]
        [Authorize(Roles = "Admin,User,Member")]
        public IActionResult Product(string? id)
        {
            ViewBag.CartId = GetCartId(GetUserId());
            var product = _context.Products.FirstOrDefault(c => c.Slug == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.CartId = GetCartId(GetUserId());
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}