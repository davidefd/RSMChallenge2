namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface ISalesOrderHeaderRepository
    {
        Task<SalesOrderHeader?> GetSalesOrderHeaderById(int id);
        Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeaders(int pageNumber);
        Task<int> CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader);
        Task<int> UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader); //Testing new method
        Task<int> DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader);
    }
}