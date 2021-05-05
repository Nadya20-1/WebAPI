using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class FridgeModel
    {
        public FridgeModel()
        {
            Fridges = new HashSet<Fridge>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }

        public virtual ICollection<Fridge> Fridges { get; set; }
    }
}
