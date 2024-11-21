using Microsoft.EntityFrameworkCore;
using Pieski.DTO;
using Pieski.Entities;
using Pieski.Interfaces;

namespace Pieski.Services
{
    public sealed class BreedService : IBreedService
    {
        private readonly ApplicationContext _context;

        public BreedService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Breed>> GetAll()
        {
            return await _context.Breeds.AsNoTracking().ToListAsync();
        }

        public async Task<Breed> GetOne(Guid Id)
        {
            var breed = await _context.Breeds.Where(b => b.Id == Id).FirstOrDefaultAsync();

            if (breed == null)
            {
                throw new Exception("Breed not found");
            }

            return breed;
        }

        public async Task<Breed> Create(CreateBreedDto dto)
        {
            Breed breed =
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                    Size = dto.Size,
                    CountryOrigin = dto.CountryOrigin,
                };

            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();

            breed = await GetOne(breed.Id);

            return breed;
        }

        public async Task<Breed> Update(Guid id, UpdateBreedDto dto)
        {
            var breed = await GetOne(id);

            breed.Name = dto.Name ?? breed.Name;
            breed.Description = dto.Description ?? breed.Description;
            breed.Size = dto.Size ?? breed.Size;
            breed.CountryOrigin = dto.CountryOrigin ?? breed.CountryOrigin;

            await _context.SaveChangesAsync();

            breed = await GetOne(id);

            return breed;
        }

        public async Task Delete(Guid Id)
        {
            var breed = await _context.Breeds.Where(b => b.Id == Id).FirstOrDefaultAsync();

            if (breed == null)
            {
                return;
            }

            _context.Remove(breed);
            await _context.SaveChangesAsync();
        }
    }
}
