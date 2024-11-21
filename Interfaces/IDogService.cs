using Pieski.DTO;
using Pieski.Entities;

namespace Pieski.Interfaces
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetAll();
        Task<Dog> GetOne(Guid Id);
        Task<Dog> Create(CreateBreedDto dto);
        Task Delete(Guid Id);
    }
}
