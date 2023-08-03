namespace Tengil.DTO
{
    public class PoInListingResponseDTO
    {
        public int Id { get; set; }
        public string NameText { get; set; } = "";
        public DateTimeOffset? DateIn { get; set; }
        public string? CustomerName { get; set; }
        public decimal? Amount { get; set; }
    }
}
