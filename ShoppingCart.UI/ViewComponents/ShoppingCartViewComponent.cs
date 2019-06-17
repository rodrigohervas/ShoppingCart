using Microsoft.AspNetCore.Mvc;
using ShoppingCart.UI.Models;
using System.Collections.Generic;

namespace ShoppingCart.UI.ViewComponents
{
    public class ShoppingCartViewComponent: ViewComponent
    {

        public ShoppingCartViewComponent()
        {

        }

        public IViewComponentResult Invoke(Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart {
                    Id = 0, 
                    CustomerName = "N/A", 
                    CustomerId = 0, 
                    Products = new List<Product>()
                };
            }

            return View("Default", cart);
        }

        private Cart GetShoppingCartContents(int customerId)
        {
            var shoppingcart = new Cart
            {
                CustomerId = customerId,
                CustomerName = "John Diligence",
                TotalPrice = 87.34,
                Products = new List<Product> {
                    new Product {Id = 1, Name = "Paddleboard", Price = 50.00M, Description = "Big board for paddeling.", Quantity = 15},
                    new Product {Id = 2, Name = "Paddle", Price = 10.00M, Description = "Composite boar to paddle.", Quantity = 18},
                    new Product {Id = 3, Name = "Lifevest", Price = 27.34M, Description = "Life vest for floating in the water.", Quantity = 21}
                }
            };

            return shoppingcart;
        }


    }
}
