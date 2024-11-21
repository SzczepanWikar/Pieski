using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pieski.DTO;
using Pieski.Entities;
using Pieski.Interfaces;

namespace Pieski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetAll()
        {
            var breeds = await _breedService.GetAll();

            return Ok(breeds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetOne(Guid id)
        {
            try
            {
                var breed = await _breedService.GetOne(id);
                return Ok(breed);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Breed>> Create([FromBody] CreateBreedDto dto)
        {
            var breed = await _breedService.Create(dto);

            return Created(string.Empty, breed);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Breed>> Update(Guid id, [FromBody] UpdateBreedDto dto)
        {
            try
            {
                var breed = await _breedService.Update(id, dto);

                return Ok(breed);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _breedService.Delete(id);

            return NoContent();
        }
    }
}
