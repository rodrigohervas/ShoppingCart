using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;


namespace ShoppingCart.UI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int QuantityLeft { get; set; }
    }
}
