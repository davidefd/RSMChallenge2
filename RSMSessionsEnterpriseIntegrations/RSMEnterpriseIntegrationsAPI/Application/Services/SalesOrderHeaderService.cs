using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
        public SalesOrderHeaderService(ISalesOrderHeaderRepository salesOrderHeaderRepository)
        {
            _salesOrderHeaderRepository = salesOrderHeaderRepository;
        }

        public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null)
            {
                throw new BadRequestException("Product info is not valid.");
            }

            SalesOrderHeader soh = new()
            {
                RevisionNumber = salesOrderHeaderDto.RevisionNumber,
                Status = salesOrderHeaderDto.Status,
                OnlineOrderFlag = salesOrderHeaderDto.OnlineOrderFlag,
                PurchaseOrderNumber = salesOrderHeaderDto.PurchaseOrderNumber,
                AccountNumber = salesOrderHeaderDto.AccountNumber,
                CustomerId = salesOrderHeaderDto.CustomerId,
                SalesPersonId = salesOrderHeaderDto.SalesPersonId,
                TerritoryId = salesOrderHeaderDto.TerritoryId,
                BillToAddressId = salesOrderHeaderDto.BillToAddressId,
                ShipToAddressId = salesOrderHeaderDto.ShipToAddressId,
                ShipMethodId = salesOrderHeaderDto.ShipMethodId,
                CreditCardId = salesOrderHeaderDto.CreditCardId,
                CreditCardApprovalCode = salesOrderHeaderDto.CreditCardApprovalCode,
                CurrencyRateId = salesOrderHeaderDto.CurrencyRateId,
                SubTotal = salesOrderHeaderDto.SubTotal,
                TaxAmt = salesOrderHeaderDto.TaxAmt,
                Freight = salesOrderHeaderDto.Freight,
                Comment = salesOrderHeaderDto.Comment
            };

            return await _salesOrderHeaderRepository.CreateSalesOrderHeader(soh);
        }

        public async Task<int> DeleteSalesOrderHeader(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }

            var soh = await ValidateSalesOrderHeaderExistence(id);
            return await _salesOrderHeaderRepository.DeleteSalesOrderHeader(soh);
        }

        public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll(int page)
        {
            var sohs = await _salesOrderHeaderRepository.GetAllSalesOrderHeaders(page);
            List<GetSalesOrderHeaderDto> sohDto = [];

            foreach (var soh in sohs)
            {
                GetSalesOrderHeaderDto dto = new()
                {
                    SalesOrderId = soh.SalesOrderId,
                    RevisionNumber = soh.RevisionNumber,
                    Status = soh.Status,
                    OnlineOrderFlag = soh.OnlineOrderFlag,
                    SalesOrderNumber = soh.SalesOrderNumber,
                    PurchaseOrderNumber = soh.PurchaseOrderNumber,
                    AccountNumber = soh.AccountNumber,
                    CustomerId = soh.CustomerId,
                    SalesPersonId = soh.SalesPersonId,
                    TerritoryId = soh.TerritoryId,
                    BillToAddressId = soh.BillToAddressId,
                    ShipToAddressId = soh.ShipToAddressId,
                    ShipMethodId = soh.ShipMethodId,
                    CreditCardId = soh.CreditCardId,
                    CreditCardApprovalCode = soh.CreditCardApprovalCode,
                    CurrencyRateId = soh.CurrencyRateId,
                    SubTotal = soh.SubTotal,
                    TaxAmt = soh.TaxAmt,
                    Freight = soh.Freight,
                    TotalDue = soh.TotalDue,
                    Comment = soh.Comment
                };

                sohDto.Add(dto);
            }

            return sohDto;

        }

        public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("SalesOrderId is not valid");
            }

            var soh = await ValidateSalesOrderHeaderExistence(id);

            GetSalesOrderHeaderDto dto = new()
            {
                SalesOrderId = soh.SalesOrderId,
                RevisionNumber = soh.RevisionNumber,
                Status = soh.Status,
                OnlineOrderFlag = soh.OnlineOrderFlag,
                SalesOrderNumber = soh.SalesOrderNumber,
                PurchaseOrderNumber = soh.PurchaseOrderNumber,
                AccountNumber = soh.AccountNumber,
                CustomerId = soh.CustomerId,
                SalesPersonId = soh.SalesPersonId,
                TerritoryId = soh.TerritoryId,
                BillToAddressId = soh.BillToAddressId,
                ShipToAddressId = soh.ShipToAddressId,
                ShipMethodId = soh.ShipMethodId,
                CreditCardId = soh.CreditCardId,
                CreditCardApprovalCode = soh.CreditCardApprovalCode,
                CurrencyRateId = soh.CurrencyRateId,
                SubTotal = soh.SubTotal,
                TaxAmt = soh.TaxAmt,
                Freight = soh.Freight,
                TotalDue = soh.TotalDue,
                Comment = soh.Comment
            };

            return dto;
        }

        //Implementing new method
        public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null)
            {
                throw new BadRequestException("ProductCategory info is not valid.");
            }

            var soh = await ValidateSalesOrderHeaderExistence(salesOrderHeaderDto.SalesOrderId);

            soh.RevisionNumber = salesOrderHeaderDto.RevisionNumber.Equals(null) ? soh.RevisionNumber : salesOrderHeaderDto.RevisionNumber;
            soh.Status = salesOrderHeaderDto.Status.Equals(null) ? soh.Status : salesOrderHeaderDto.Status;
            soh.OnlineOrderFlag = salesOrderHeaderDto.OnlineOrderFlag.Equals(null) ? soh.OnlineOrderFlag : salesOrderHeaderDto.OnlineOrderFlag;
            soh.AccountNumber = string.IsNullOrWhiteSpace(salesOrderHeaderDto.AccountNumber) ? soh.AccountNumber : salesOrderHeaderDto.AccountNumber;
            soh.SalesPersonId = salesOrderHeaderDto.SalesPersonId.Equals(null) ? soh.SalesPersonId : salesOrderHeaderDto.SalesPersonId;
            soh.TerritoryId = salesOrderHeaderDto.TerritoryId.Equals(null) ? soh.TerritoryId : salesOrderHeaderDto.TerritoryId;
            soh.CreditCardId = salesOrderHeaderDto.CreditCardId.Equals(null) ? soh.CreditCardId : salesOrderHeaderDto.CreditCardId;
            soh.CreditCardApprovalCode = string.IsNullOrWhiteSpace(salesOrderHeaderDto.CreditCardApprovalCode) ? soh.CreditCardApprovalCode : salesOrderHeaderDto.CreditCardApprovalCode;
            soh.CurrencyRateId = salesOrderHeaderDto.CurrencyRateId.Equals(null) ? soh.CurrencyRateId : salesOrderHeaderDto.CurrencyRateId;
            soh.SubTotal = salesOrderHeaderDto.SubTotal.Equals(null) ? soh.SubTotal : salesOrderHeaderDto.SubTotal;
            soh.TaxAmt = salesOrderHeaderDto.TaxAmt.Equals(null) ? soh.TaxAmt : salesOrderHeaderDto.TaxAmt;
            soh.Freight = salesOrderHeaderDto.Freight.Equals(null) ? soh.Freight : salesOrderHeaderDto.Freight;
            soh.Comment = string.IsNullOrWhiteSpace(salesOrderHeaderDto.Comment) ? soh.Comment : salesOrderHeaderDto.Comment;
            soh.PurchaseOrderNumber = string.IsNullOrWhiteSpace(salesOrderHeaderDto.PurchaseOrderNumber) ? soh.PurchaseOrderNumber : salesOrderHeaderDto.PurchaseOrderNumber;

            return await _salesOrderHeaderRepository.UpdateSalesOrderHeader(soh);
        }

        private async Task<SalesOrderHeader> ValidateSalesOrderHeaderExistence(int id)
        {
            var existingSalesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id)
                            ?? throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

            return existingSalesOrderHeader;
        }
    }
}
