using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using MyApi.Models;
using MyApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost] // <-- atributo correcto
        public async Task<ActionResult> Post(ReviewCreateDto dto)
        {
            var review = new Review
            {
                Comment = dto.Comment,
                Rating = dto.Rating,
                UserId = dto.UserId,
                PlatformId = dto.PlatformId
            };

            _context.Add(review);
            await _context.SaveChangesAsync();

            return Ok("Review creada correctamente");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Platform)
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(u => u.Id == id);

            if (review == null)
            {
                return NotFound("reseña no encotreada");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("Reseña eliminado correctamente");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ReviewUpdateDto dto)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound("Review no encontrada");
            }

            review.Comment = dto.Comment;
            review.Rating = dto.Rating;

            await _context.SaveChangesAsync();

            return Ok("Review actualizada correctamente");
        }

    }
}
