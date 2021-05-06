using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.POST_request
{
    public class FridgeModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public virtual ICollection<FridgeDTO> Fridges { get; set; }
    }
}
