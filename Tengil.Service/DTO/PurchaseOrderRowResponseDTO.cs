using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengil.Service.DTO
{
    public class PurchaseOrderRowResponseDTO
    {
        public int Id { get; set; }
        public string RowText { get; set; } = "";

        public int? UnitId { get; set; }

        public decimal? Extent { get; set; }

        public decimal? PricePerUnit { get; set; }

        public double? Vat { get; set; }

        public double? Discount { get; set; }
    }
}
