namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface ISalesOrderHeaderService
    {
        Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id);
        Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll(int page);
        Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto);
        Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto);
        Task<int> DeleteSalesOrderHeader(int id);
    }
}