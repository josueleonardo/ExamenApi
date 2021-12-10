using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDApiTarea.Models
{
    public class DB
    {
        public static List<Product> Products = new List<Product>();

        public static Product FindProduct(int id)
        {
            Product product;

            product = Products.Find(p => p.id == id);

            return (product);
        }
        public static bool addProduct(Product product)
        {
            Products.Add(product);

            return (true);

        }
    }
}