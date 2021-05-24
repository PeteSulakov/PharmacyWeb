using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Models
{
	public class ShoppingCart
	{
        private readonly PharmacyContext _context;
        public ShoppingCart(PharmacyContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<PharmacyContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public async Task AddToCartAsync(Medicine medicine, int amount)
        {
            var shoppingCartItem =
                    await _context.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Medicine.Id == medicine.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Medicine = medicine,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
                --medicine.Amount;
            }
            else
            {
                if (shoppingCartItem.Amount < medicine.Amount)
                {
                    shoppingCartItem.Amount++;
                    --medicine.Amount;
                }
                else if (shoppingCartItem.Amount >= medicine.Amount && medicine.Amount != 0)
                {
                    shoppingCartItem.Amount++;
                    --medicine.Amount;
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task RemoveCartAsync(Medicine medicine)
        {
            var shoppingCartItem =
                    await _context.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Medicine.Id == medicine.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {

                _context.ShoppingCartItems.Remove(shoppingCartItem);

            }
            await _context.SaveChangesAsync();

        }

        public async Task<int> RemoveFromCartAsync(Medicine medicine)
        {
            var shoppingCartItem =
                    await _context.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Medicine.Id == medicine.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                    ++medicine.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                    ++medicine.Amount;
                }
            }

            await _context.SaveChangesAsync();

            return localAmount;
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems = await
                       _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Medicine)
                           .ToListAsync());
        }

        public async Task ClearCartAsync()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Medicine.Price * c.Amount).Sum();
            return total;
        }
    }
}
