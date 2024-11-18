namespace KartRacer.API.Models.Dto
{
    public class CurrentPartDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = String.Empty;
        public Boolean OnCurrentKart { get; init; }
        public string PartType { get; init; } = String.Empty;
        public Byte Status { get; init; }
        public decimal Value { get; init; }

    }
}
