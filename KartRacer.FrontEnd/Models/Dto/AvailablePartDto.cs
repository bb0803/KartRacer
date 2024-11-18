namespace KartRacer.FrontEnd.Models.Dto
{
    public class AvailablePartDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = String.Empty;
        public decimal Cost { get; init; }
        public string PartType { get; init; } = String.Empty;

    }
}
