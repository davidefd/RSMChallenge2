namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderId { get; set; }
        public byte? RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public DateTime ShipDate { get; set; } = DateTime.Now;
        public byte? Status { get; set; }
        public bool? OnlineOrderFlag { get; set; }
        public string? SalesOrderNumber { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? AccountNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public int? TerritoryId { get; set; }
        public int? BillToAddressId { get; set; }
        public int? ShipToAddressId { get; set; }
        public int? ShipMethodId { get; set; }
        public int? CreditCardId { get; set; }
        public string? CreditCardApprovalCode { get; set; }
        public int? CurrencyRateId { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmt { get; set; } 
        public decimal? Freight { get; set; }
        public decimal? TotalDue { get; set; } 
        public string? Comment { get; set; }
        //public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}