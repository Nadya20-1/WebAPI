using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public class POSTService : IPOSTService
    {
        private readonly FridgeDBContext _context;
        private readonly IMapper _mapper;

        public POSTService(FridgeDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<POSTFridgeProducts>> CreateFridgeProducts(POSTFridgeProducts addFridgeProducts)
        {
            ServiceResponse<POSTFridgeProducts> response = new ServiceResponse<POSTFridgeProducts>();
            try
            {
                Fridge fridge = await _context.Fridges
                    .Include(c => c.Model)
                    .Include(c => c.FridgeProducts).ThenInclude(cs => cs.Product)
                    .FirstOrDefaultAsync(c => c.Id == addFridgeProducts.FridgeId);
                if (fridge == null)
                {
                    response.Success = false;
                    response.Message = "Fridge not found";
                    return response;
                }
                Product product = await _context.Products
                    .FirstOrDefaultAsync(s => s.Id == addFridgeProducts.ProductId);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                    return response;
                }
  
                FridgeProduct fridgeProduct = new FridgeProduct
                {         
                    Id = addFridgeProducts.Id,
                    Product = product,
                    Fridge = fridge,
                    Quantity = addFridgeProducts.Quantity,
                };

                await _context.FridgeProducts.AddAsync(fridgeProduct);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<POSTFridgeProducts>(fridgeProduct);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<PUTFridge>> UpadateFridge(PUTFridge updateFridge)
        {
            ServiceResponse<PUTFridge> response = new ServiceResponse<PUTFridge>();
            try
            {
                FridgeModel model = await _context.FridgeModels
                    .FirstOrDefaultAsync(c => c.Id == updateFridge.ModelId);
                if (model == null)
                {
                    response.Success = false;
                    response.Message = "FridgeModel not found";
                    return response;
                }

                Fridge fridge = new Fridge
                {
                    Id = updateFridge.Id,
                    Name = updateFridge.Name,
                    OwnerName = updateFridge.OwnerName,
                    Model = model,
                };

                _context.Fridges.Update(fridge);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<PUTFridge>(fridge);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
