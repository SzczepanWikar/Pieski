namespace Pieski.Entities
{
    public sealed class Dog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Breed? Breed { get; set; }
    }
}
