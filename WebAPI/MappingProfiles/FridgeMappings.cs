using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.DTO;

namespace WebAPI.MappingProfiles
{
    public class FridgeMappings : Profile
    {
        public FridgeMappings()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<FridgeProduct, POSTFridgeProducts>();
            CreateMap<Fridge, PUTFridge>();
            CreateMap<Fridge, FridgeDTO>()
                 .ForMember(dto => dto.Model, c => c.MapFrom(c => c.FridgeProducts.Select(cs => cs.Product)));
        }
    }
}
