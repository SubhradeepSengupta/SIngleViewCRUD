using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeModelsController : ControllerBase
    {
        private readonly HomeModelContext _context;

        public HomeModelsController(HomeModelContext context)
        {
            _context = context;
        }

        // GET: api/HomeModels
        [HttpGet]
        public IEnumerable<HomeModel> GetTestData()
        {
            return _context.TestData;
        }

        // GET: api/HomeModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomeModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var homeModel = await _context.TestData.FindAsync(id);

            if (homeModel == null)
            {
                return NotFound();
            }

            return Ok(homeModel);
        }

        // PUT: api/HomeModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeModel([FromRoute] int id, [FromBody] HomeModel homeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != homeModel.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(homeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HomeModels
        [HttpPost]
        public async Task<IActionResult> PostHomeModel([FromBody] HomeModel homeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TestData.Add(homeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeModel", new { id = homeModel.PersonId }, homeModel);
        }

        // DELETE: api/HomeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var homeModel = await _context.TestData.FindAsync(id);
            if (homeModel == null)
            {
                return NotFound();
            }

            _context.TestData.Remove(homeModel);
            await _context.SaveChangesAsync();

            return Ok(homeModel);
        }

        private bool HomeModelExists(int id)
        {
            return _context.TestData.Any(e => e.PersonId == id);
        }
    }
}