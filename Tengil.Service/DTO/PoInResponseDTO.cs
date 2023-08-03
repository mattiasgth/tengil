using tngcmd.Data;

namespace Tengil.DTO
{
    public class PoInResponseDTO
    {
        public int Id { get; set; }


        public DateTime? DateIn { get; set; }

        public string? InvoiceName { get; set; }

        public string? Filename { get; set; }

        public string? Location { get; set; }

        public string? NameText { get; set; }

        public decimal? Amount { get; set; }

        public string? CurrencyName { get; set; }

        public int? InvoiceId { get; set; }

        public string? Comment { get; set; }

        public int? CustomerId { get; set; }

        public int? AddedById { get; set; }

    }
}
