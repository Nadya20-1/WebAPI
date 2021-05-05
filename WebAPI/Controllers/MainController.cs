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
        private IOptions<DbConnection> _connectionSettings;

        public MainController(FridgeDBContext context, IOptions<DbConnection> connectionSettings)
        {
            _context = context;
            _connectionSettings = connectionSettings;
        }

        // GET: Fridge
        [HttpGet("GetFridge")]
        [ActivatorUtilitiesConstructor]
        public async Task<IEnumerable<Fridge>> GetFridgeAsync()
        {
            return await _context.Fridges.ToListAsync();
        }

        // GET: FridgeProduct
        [HttpGet("GetFridgeProduct")]
        [ActivatorUtilitiesConstructor]
        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductAsync()
        {
            return await _context.FridgeProducts.ToListAsync();
        }


        // POST: Product/Create
        [HttpPost("PostProducts")]
        [ActivatorUtilitiesConstructor]
        public async Task<IActionResult> PostProductsAsync([Bind("Id,Name,DefaultQuantity")] Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // POST: Product/Delete/5
        [HttpDelete("DeleteProducts"), ActionName("Delete")]
        [ActivatorUtilitiesConstructor]
        public async Task<IActionResult> DeleteProductsAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
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
