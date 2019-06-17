using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.UI.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
