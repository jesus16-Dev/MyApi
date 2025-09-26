using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using MyApi.Models;
using MyApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/platform")]
    public class PlatformController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlatformController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Post(PlatformCreateDto dto)
        {
            var platform = new Platform
            {
                Name = dto.Name
            };

            _context.Add(platform);
            await _context.SaveChangesAsync();

            return Ok("Plataforma creada");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> Get()
        {
            return await _context.Platforms.ToListAsync();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, PlatformUpdateDto dto)
        {
            var platform = await _context.Platforms.FindAsync(id);

            if (platform == null)
            {
                return NotFound("Plataforma no encontrada");
            }

            platform.Name = dto.Name;

            await _context.SaveChangesAsync();

            return Ok(platform); // Devuelve el objeto actualizado
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);

            if (platform == null)
            {
                return NotFound("Plataforma no encontrada");
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return Ok("Plataforma eliminada correctamente");
        }

    }
}
