using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tngcmd.Data;

namespace tngcmd
{
    public class InvoiceProcessor
    {
        private readonly ILogger<InvoiceProcessor> _logger;
        private readonly TengilContext _context;

        public InvoiceProcessor(ILogger<InvoiceProcessor> logger, TengilContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> Run()
        {
            _logger.LogDebug("Testing Run()");
            var invoices = await _context.TngInvoices.ToListAsync();
            return 0;
        }
    }
}
