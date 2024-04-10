namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateSalesOrderHeaderDto
    {
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? AccountNumber { get; set; }
        public int? SalesPersonId { get; set; }
        public int? TerritoryId { get; set; }
        public int? CreditCardId { get; set; }
        public string? CreditCardApprovalCode { get; set; }
        public int? CurrencyRateId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public string? Comment { get; set; }

    }

}