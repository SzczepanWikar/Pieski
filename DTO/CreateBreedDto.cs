using Pieski.Entities;

namespace Pieski.DTO
{
    public sealed record CreateBreedDto(string Name, string Description, BreedSize Size, string CountryOrigin);
}
