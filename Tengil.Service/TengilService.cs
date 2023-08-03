using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tengil.DTO;
using Tengil.Service.DTO;
using tngcmd.Data;

namespace Tengil.Service
{
    public class TengilService
    {
        private readonly ILogger<TengilService> _logger;
        private readonly TengilContext _context;

        public TengilService(ILogger<TengilService> logger, TengilContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<TngCustomer>> GetCustomers(int skip, int take)
        {
            var rslt = await _context.TngCustomers
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return rslt;
        }

        public async Task<TngCustomer?> GetCustomerById(int id)
        {
            var rslt = await _context.TngCustomers.FindAsync(id);
            return rslt;
        }

        #region Invoices
        public async Task<TngInvoice?> GetInvoiceById(int id)
        {
            var rslt = await _context.TngInvoices.FindAsync(id);
            return rslt;
        }

        public async Task<IEnumerable<TngInvoice>> GetInvoices(int skip, int take)
        {
            var rslt = await _context.TngInvoices
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return rslt;
        }

        public async Task<TngInvoice> InsertOrUpdateInvoice(TngInvoice invoice, InvoiceRequestDTO dto)
        {
            if (dto.DatePaid.HasValue)
            {
                var date = dto.DatePaid.Value.ToLocalTime();
                invoice.DatePaid = new DateTime(date.Year, date.Month, date.Day);
            }
            _context.Attach(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
        #endregion

        #region Assignments
        public async Task<TngAssignment?> GetAssignmentById(int id)
        {
            var rslt = await _context.TngAssignments.FindAsync(id);
            return rslt;
        }

        public async Task<IEnumerable<TngAssignment>> GetAssignments(int skip, int take)
        {
            var rslt = await _context.TngAssignments
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return rslt;
        }

        public async Task<TngAssignment> InsertOrUpdateAssignment(TngAssignment assignment, AssignmentRequestDTO dto)
        {
            _context.Attach(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }
        #endregion

        #region PoIn
        public async Task<TngPoIn?> GetPoInById(int id)
        {
            var rslt = await _context.TngPoins.FindAsync(id);
            return rslt;
        }

        public async Task<IEnumerable<TngPoIn>> GetPoIns(int skip, int take)
        {
            var rslt = await _context.TngPoins
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return rslt;
        }

        public async Task<TngPoIn> InsertOrUpdatePoIn(TngPoIn poIn, PoInRequestDTO dto)
        {
            _context.Attach(poIn);
            await _context.SaveChangesAsync();
            return poIn;
        }

        public async Task<IEnumerable<TngStatusValue>> GetStatusValues()
        {
            var rslt = await _context.TngStatusValues
                .ToListAsync();
            return rslt;
        }
        #endregion
    }
}