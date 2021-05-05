using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class FridgeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FridgeId { get; set; }
        public int Quantity { get; set; }

        public virtual Fridge Fridge { get; set; }
        public virtual Product Product { get; set; }
    }
}
