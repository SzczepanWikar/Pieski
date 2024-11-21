namespace Pieski.Entities
{
    public enum BreedSize
    {
        XS,
        S,
        M,
        L,
        XL
    }
    public sealed class Breed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BreedSize Size { get; set; }
        public string CountryOrigin { get; set; }
    }
}
