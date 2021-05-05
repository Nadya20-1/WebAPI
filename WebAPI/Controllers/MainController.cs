using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    { 
        private readonly ILogger<MainController> _logger;
        private readonly FridgeDBContext _context;

        public MainController(FridgeDBContext context)
        {
            _context = context;
        }

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        // GET: Fridge
        [HttpGet]
        public async Task<IActionResult> GetFridge()
        {
            var fridgeDBContext = _context.Fridges.Include(f => f.Model);
            return await fridgeDBContext.ToListAsync();
        }

        // GET: FridgeProduct
        [HttpGet]
        public async Task<IActionResult> GetFridgeProduct()
        {
            var fridgeDBContext = _context.FridgeProducts.Include(f => f.Fridge).Include(f => f.Product);
            return await fridgeDBContext.ToListAsync();
        }


        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostProducts([Bind("Id,Name,DefaultQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            return Ok(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction();
        }

        // POST: Fridge
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OwnerName,ModelId")] Fridge fridge)
        {
            if (id != fridge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(fridge);
                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            ViewData["ModelId"] = new SelectList(_context.FridgeModels, "Id", "Id", fridge.ModelId);
            return Ok(fridge);
        }


    }
}
