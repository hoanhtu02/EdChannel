using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EdChannel.Data;
using EdChannel.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using SendGrid.Helpers.Mail;
using NuGet.Packaging;
using Humanizer;

namespace EdChannel.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin,Member")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Dashboard/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.User).Include(p=>p.ProductCategories).ThenInclude(pt=>pt.Category);
            ViewData["Category"] = new SelectList(_context.Categories.Where(cat=>cat.ParentId==null), "Id", "Title");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dashboard/Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Dashboard/Products/Create
        public IActionResult Create()
        {

            
            ViewData["Category"] = new SelectList(_context.Categories.Where(cat => cat.ParentId == null).ToList(), "Id", "Title");
            ViewData["SubCategory"] = _context.Categories.Where(cat => cat.ParentId != null).ToList();
            ViewData["Tags"] = new SelectList(_context.Tags, "Id", "Title");

            return View();
        }

        // POST: Dashboard/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title,MetaTitle,Slug,Summary,Type,SKU,Price,Discount,Quantity,Image,ImageFile,IsPublished,PublishedAt,StartAt,EndAt,Details,CreatedAt,ModifiedAt,SubCategoryId,FullStringTags")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile!= null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using var fileStream = new FileStream(path, FileMode.Create);
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.Discount ??= 0;
                product.UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                product.User = _context.Users.Find(long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                _context.Add(product);
                await _context.SaveChangesAsync();
                
                if (product.SubCategoryId != null)
                {
                    ProductCategory productCategory = new()
                    {
                        CategoryId = (long)product.SubCategoryId,
                        ProductId = product.Id
                    };
                    _context.Add(productCategory);
                    await _context.SaveChangesAsync();
                }
                if (product.FullStringTags != null && product.FullStringTags.Count > 0)
                {
                    List<ProductTag> productTags = new ();
                    foreach (var item in product.FullStringTags)
                    {
                        if (long.TryParse(item, out long result))
                        {
                            productTags.Add(new ProductTag()
                            {
                                ProductId = product.Id,
                                TagId = result
                            });
                        }
                        else
                        {
                            Tag tag = new() {
                                Title= item,
                                MetaTitle="Need to change value...",
                                Slug= item,
                                Details= item
                            };
                            _context.Add(tag);
                            await _context.SaveChangesAsync();
                            productTags.Add(new ProductTag()
                            {
                                ProductId = product.Id,
                                TagId = tag.Id
                            });
                        }
                    }
                    _context.AddRange(productTags);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Dashboard/Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            if (_context.ProductTags != null)
            {
            product.FullStringTags ??= new List<string>();
                var result = _context.ProductTags
                    .Where(pt => pt.ProductId == id)
                    .Join(_context.Tags, pt => pt.TagId, t => t.Id, (pt, t) => t.Id)
                    .ToList();
                foreach (var item in result)
                {
                product.FullStringTags.Add(item.ToString());
                }
                ViewBag.Tags = _context.Tags.Select( (t) => new TagM{ Id = t.Id, Title = t.Title }).ToList();
            }
            ViewData["Category"] = new SelectList(_context.Categories.Where(cat => cat.ParentId == null), "Id", "Title");
            ViewData["SubCategory"] = _context.Categories.Where(cat => cat.ParentId != null);
            return View(product);
        }
        public async Task<IActionResult> Category(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Dashboard/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,Title,MetaTitle,Slug,Summary,Type,SKU,Price,Discount,Quantity,Image,ImageFile,IsPublished,PublishedAt,StartAt,EndAt,Details,CreatedAt,ModifiedAt,SubCategoryId,FullStringTags")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (product.SubCategoryId != null)
                        {
                            var currPc = _context.ProductCategories.FirstOrDefault(pc => pc.CategoryId == product.SubCategoryId && pc.ProductId == product.Id);
                            if (currPc != null)
                            {
                                _context.ProductCategories.Remove(currPc);
                            }
                            await _context.ProductCategories.AddAsync(new ProductCategory() { ProductId = product.Id, CategoryId = (long)product.SubCategoryId });
                            await _context.SaveChangesAsync();
                        }

                        if (product.FullStringTags != null && product.FullStringTags.Count > 0)
                        {
                            var existTags = _context.ProductTags.Where(pt => pt.ProductId == product.Id).ToList();
                            List<ProductTag> productTags = new();
                            var removeTags = existTags.Where(pt => !product.FullStringTags.Contains(pt.TagId.ToString())).ToList();
                            if (removeTags != null)
                            {
                                foreach (var tag in removeTags)
                                {
                                    _context.ProductTags.Remove(tag);
                                }
                                await _context.SaveChangesAsync();
                            }
                            foreach (var item in product.FullStringTags)
                            {
                                if (long.TryParse(item, out long result))
                                {
                                    if (!existTags.Any(pt => pt.TagId == result))
                                    {
                                        productTags.Add(new ProductTag()
                                        {
                                            ProductId = product.Id,
                                            TagId = result
                                        });
                                    }

                                }
                                else
                                {
                                    Tag tag = new()
                                    {
                                        Title = item,
                                        MetaTitle = "Need to change value...",
                                        Slug = item,
                                        Details = item
                                    };
                                    _context.Tags.Add(tag);
                                    await _context.SaveChangesAsync();
                                    productTags.Add(new ProductTag()
                                    {
                                        ProductId = product.Id,
                                        TagId = tag.Id
                                    });
                                }
                            }
                            _context.ProductTags.AddRange(productTags);
                            await _context.SaveChangesAsync();
                        }

                        if (product.ImageFile != null)
                        {
                            if (product.Image != null) System.IO.File.Delete(_hostEnvironment.WebRootPath + "/Images/" + product.Image);
                            string wwwRootPath = _hostEnvironment.WebRootPath;
                            string fileNameFromView = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                            string extension = Path.GetExtension(product.ImageFile.FileName);
                            product.Image = fileNameFromView = fileNameFromView + DateTime.Now.ToString("yymmssfff") + extension;
                            string path = Path.Combine(wwwRootPath + "/Images/", fileNameFromView);
                            using var fileStream = new FileStream(path, FileMode.Create);
                            await product.ImageFile.CopyToAsync(fileStream);
                        }
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
            }
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Dashboard/Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Dashboard/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (product.Image != null)
                {
                    System.IO.File.Delete(_hostEnvironment.WebRootPath + "/Images/" + product.Image);
                }
                var existProCat = _context.ProductCategories.Where(pc => pc.ProductId == id);
                var existProTag = _context.ProductTags.Where(pc => pc.ProductId == id);
                var existProMeta = _context.ProductMeta.Where(pc => pc.ProductId == id);
                if (existProCat != null)
                {
                    _context.ProductCategories.RemoveRange(existProCat);
                }
                if (existProTag != null)
                {
                    _context.ProductTags.RemoveRange(existProTag);
                }
                if (existProMeta != null)
                {
                    _context.ProductMeta.RemoveRange(existProMeta);
                }
                _context.Products.Remove(product);
            }
            
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
