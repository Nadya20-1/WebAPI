using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    { 
        private readonly FridgeDBContext _context;

        public MainController(FridgeDBContext context)
        {
            _context = context;
        }

        // GET: Fridge
        [HttpGet("GetFridge")]
        [ActivatorUtilitiesConstructor]
        public async Task<IEnumerable<Fridge>> GetFridgeAsync()
        {
            return await _context.Fridges.ToListAsync();
        }

        // GET: FridgeProducts
        [HttpGet("GetFridgeProducts")]
        [ActivatorUtilitiesConstructor]
        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductAsync()
        {
            return await _context.FridgeProducts.ToListAsync();
        }


        // POST: FridgeProducts
        [HttpPost("PostFridgeProducts")]
        [ActivatorUtilitiesConstructor]
        public async Task<IActionResult> PostFridgeProductsAsync([Bind("Id,ProductId,FridgeId,Quantity")] FridgeProduct fridgeProduct)
        {
            await _context.AddAsync(fridgeProduct);
            await _context.SaveChangesAsync();
            return Ok(fridgeProduct);
        }

        // DELETE: Products
        [HttpDelete("DeleteFridgeProducts"), ActionName("Delete")]
        [ActivatorUtilitiesConstructor]
        public async Task<IActionResult> DeleteProductsAsync(int id)
        {
            var product = await _context.FridgeProducts.FindAsync(id);
            _context.FridgeProducts.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(id);
        }

        // PUT: Fridge
        [HttpPut("UpdateFridge")]
        [ActivatorUtilitiesConstructor]
        public async Task<IActionResult> UpdateFridgeAsync([Bind("Id,Name,OwnerName,ModelId")] Fridge fridge)
        {
            _context.Update(fridge);
            await _context.SaveChangesAsync();
            return Ok(fridge);
        }

    }
}
