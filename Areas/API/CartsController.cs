using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdChannel.Data;
using EdChannel.Models;

namespace EdChannel.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
          if (_context.Carts == null)
          {
              return NotFound();
          }
            return await _context.Carts.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<CartItem>>> GetCart(long id)
        {
          if (_context.Carts == null)
          {
              return NotFound();
          }
            var cart = await _context.Carts.FindAsync(id);
            var cartItems = _context.CartItems.Where(c => c.CartId == cart.Id).Include(c => c.Product).ToList();
            if (cart == null)
            {
                return NotFound();
            }
            return cartItems;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(long id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Route("/api/add-cart/{cartId}/add")]
        public async Task<IActionResult> AddToCart(long cartId ,[FromForm] CartItem cartItem)
        {
            try
            {
                if (_context.Carts == null)
                {
                    return NotFound();
                }
                var cartItems = _context.CartItems.FirstOrDefault(c => c.CartId == cartId && c.ProductId == cartItem.ProductId);
                if (cartItems == null)
                {
                    cartItems = new CartItem
                    {
                        CartId = cartId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        CreatedAt = DateTime.Now,
                    };
                    _context.CartItems.Add(cartItems);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cartItems.Quantity = cartItem.Quantity;
                    cartItems.ModifiedAt = DateTime.Now;
                    _context.Entry(cartItems).State = EntityState.Modified;
                    _context.CartItems.Update(cartItems);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("/api/remove-cart/{cartId}/remove")]
        public async Task<IActionResult> RemoveFromCart(long cartId, [FromForm] CartItem cartItem)
        {
            var cartItems = _context.CartItems.FirstOrDefault(c => c.CartId == cartId && c.ProductId == cartItem.ProductId);
            if (cartItems == null)
            {
                return NotFound();
            }
            else
            {
                _context.CartItems.Remove(cartItems);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
          if (_context.Carts == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Carts'  is null.");
          }
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(long id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
