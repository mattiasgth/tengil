namespace Tengil.DTO
{
    public class PoInListingResponseDTO
    {
        public int Id { get; set; }
        public string NameText { get; set; } = "";
        public DateTimeOffset? DateIn { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Amount { get; set; }
    }
}
