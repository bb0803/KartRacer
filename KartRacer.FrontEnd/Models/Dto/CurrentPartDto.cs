namespace KartRacer.FrontEnd.Models.Dto
{
    public class CurrentPartDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public Boolean OnCurrentKart { get; init; }
        public string PartType { get; init; }
        public Byte Status { get; init; }
        public decimal Value { get; init; }
    }
}
