using Pieski.Entities;

namespace Pieski.DTO
{
    public sealed record UpdateBreedDto(string? Name, string? Description, BreedSize? Size, string? CountryOrigin);
}
