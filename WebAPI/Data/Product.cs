using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class Product
    {
        public Product()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }

        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
