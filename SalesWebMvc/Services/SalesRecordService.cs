using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? initial, DateTime? final)
        {
            var result = _context.SalesRecord.Select(x => x);

            if (initial.HasValue)
            {
                result = result.Where(x => x.Date >= initial);
            }
            if (final.HasValue)
            {
                result = result.Where(x => x.Date <= final);
            }

            return await result
                .Include(sr => sr.Seller)
                .Include(sr => sr.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

    }
}
