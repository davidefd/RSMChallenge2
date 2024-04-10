namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SalesOrderHeaderRepository : ISalesOrderHeaderRepository
    {
        private readonly AdvWorksDbContext _context;
        public SalesOrderHeaderRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            await _context.AddAsync(salesOrderHeader);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            _context.Remove(salesOrderHeader);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeaders(int pageNumber)
        {
            var pageSize = 1000f;
            var pageCount = Math.Ceiling(_context.SalesOrderHeaders.Count() / pageSize);

            return await _context.Set<SalesOrderHeader>()
                .OrderBy(s => s.SalesOrderId)
                .Skip((pageNumber - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToListAsync();
        }

        public async Task<SalesOrderHeader?> GetSalesOrderHeaderById(int id)
        {
            return await _context.SalesOrderHeaders
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.SalesOrderId == id);
        }

        public async Task<int> UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("DISABLE TRIGGER ALL ON Sales.SalesOrderHeader");
                    _context.Update(salesOrderHeader);
                    int affectedRows = await _context.SaveChangesAsync();

                    await _context.Database.ExecuteSqlRawAsync("ENABLE TRIGGER ALL ON Sales.SalesOrderHeader");
                    await transaction.CommitAsync();

                    return affectedRows;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
