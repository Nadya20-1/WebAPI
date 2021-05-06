using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO.POST_request;

namespace WebAPI.DTO
{
    public class FridgeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public int ModelId { get; set; }
        public virtual FridgeModelDTO Model { get; set; }
    }
}
