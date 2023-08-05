using AutoMapper;
using Tengil.DTO;
using Tengil.Service.DTO;
using tngcmd.Data;

namespace Tengil.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TngPoIn, PoInListingResponseDTO>();
            CreateMap<TngPoIn, PoInResponseDTO>();
            CreateMap<TngInvoiceRow, PurchaseOrderRowResponseDTO>();
            CreateMap<TngAssignment, AssignmentListingResponseDTO>();
            CreateMap<TngAssignment, AssignmentResponseDTO>();
            CreateMap<TngInvoice, InvoiceListingResponseDTO>();
            CreateMap<TngInvoice, InvoiceResponseDTO>();
            CreateMap<TngCustomer, CustomerResponseDTO>();
        }
    }
}
