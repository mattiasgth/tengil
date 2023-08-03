using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengil.Service.DTO
{
    public class AssignmentListingResponseDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime? DateIn { get; set; }
        public int? ExtentApprox { get; set; }
        public decimal? Vat { get; set; }
        public string? NameText { get; set; }
    }
}
