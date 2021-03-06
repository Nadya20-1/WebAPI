using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class Fridge
    {
        public Fridge()
        {
            FridgeProducts = new HashSet<FridgeProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public int ModelId { get; set; }

        public virtual FridgeModel Model { get; set; }
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}
