using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.UI.Models;
using ShoppingCart.UI.Session;

namespace ShoppingCart.UI.Controllers
{
    public class HomeController : Controller
    {
        //TEST OBJECTS: Customer, Products, Cart
        private static Customer customer = new Customer
        {
            Id = 1,
            FullName = "Blas De Lezo"
        };
        
        private static List<Product> products = new List<Product> {
                new Product { Id = 2, Name = "Binder",
                    Description = "3-ring binder with round 1-inch rings that hold up to 175 sheets of paper, All binder size refer to ring size, not binder spine.", Price = 19.99M, Quantity = 1, QuantityLeft = 10 },
                new Product { Id = 3, Name = "Pen",
                    Description = "Stainless steel sleek, streamlined design designer pens in Red, Blue and Black", Price = 4.50M, Quantity = 1, QuantityLeft = 83 },
                new Product { Id = 4, Name = "Chromebook",
                    Description = "11.6 Pintel Meliton Processor F1221, 4GB system Memory, 32GB eMMC flash memory", Price = 220.00M, Quantity = 1, QuantityLeft = 7 },
                new Product { Id = 5, Name = "Notebook",
                    Description = "Large classic notebook with 240 ruled pages (front and back) made from acid-free paper", Price = 3.99M, Quantity = 1, QuantityLeft = 21 },
                new Product { Id = 6, Name = "Backpack",
                    Description = "Unisex Classic Lightweight Water-resistant Backpack. Schoolbag Travel Bookbag in Black", Price = 39.99M, Quantity = 1, QuantityLeft = 14 }
            };

        private Cart cart = new Cart
        {
            Id = 27,
            CustomerId = customer.Id,
            CustomerName = customer.FullName,
            Products = products
        };


        public IActionResult Index()
        {
            return View(products);
        }


        public IActionResult kjhslkijgfhlisdfujhgidslfuhdilfuhdifubhdifugbh()
        {
            var shopCart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            if (shopCart != null)
            {
                products = shopCart.Products;
            }

            return View(products);
        }


        public IActionResult AddProductToCart(Product product)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            var shopCart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            if (shopCart == null)
            {
                shopCart = new Cart
                {
                    Id = cart.Id,
                    CustomerId = cart.CustomerId,
                    CustomerName = cart.CustomerName,
                    TotalPrice = cart.TotalPrice,
                    Products = new List<Product>()
                };
            }

            if (shopCart.Products.Exists(p => p.Id == product.Id))
            {
                shopCart.Products.First(p => p.Id == product.Id).Quantity += product.Quantity;
            }
            else
            {
                shopCart.Products.Add(
                    new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
            }

            SessionHelper.Set<Cart>(HttpContext.Session, "cart", shopCart);

            return View("SavedCart", shopCart);
        }


        public IActionResult Info()
        {
            return View();
        }


        public IActionResult Session()
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            Cart shoppingCart = null;

            shoppingCart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            return View(shoppingCart);
        }


        public IActionResult AddVarsToSession(int age, string gender)
        {
            if (age != 0 && !string.IsNullOrEmpty(gender))
            {
                HttpContext.Session.Set("age", age);
                HttpContext.Session.Set("gender", gender);
            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
