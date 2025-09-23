using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Carts
    {
        public ProductInfo Product {get; set ; }
        public int Quantity { get; set; }
        public Carts(ProductInfo product , int soluong)
        {
            Product = product;
            Quantity = soluong;
        }

    }
}