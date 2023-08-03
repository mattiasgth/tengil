using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengil.Service.DTO
{
    public class InvoiceResponseDTO
    {
        public int Id { get; set; }
        public string InvoiceText { get; set; } = null!;
        public DateTime? DateIssued { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Vat { get; set; }
        public string? CurrencyName { get; set; }
    }
}
