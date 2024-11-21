using Pieski.DTO;
using Pieski.Entities;

namespace Pieski.Interfaces
{
    public interface IBreedService
    {
        Task<IEnumerable<Breed>> GetAll();
        Task<Breed> GetOne(Guid Id);
        Task<Breed> Create(CreateBreedDto dto);
        Task<Breed> Update(Guid id, UpdateBreedDto dto);
        Task Delete(Guid Id);
    }
}
