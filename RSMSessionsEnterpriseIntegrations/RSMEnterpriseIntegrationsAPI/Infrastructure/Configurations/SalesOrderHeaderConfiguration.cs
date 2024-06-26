namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.SalesOrderId);
            builder.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

            builder.Property(e => e.RevisionNumber).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.OnlineOrderFlag).IsRequired();

            builder.Property(e => e.SalesOrderNumber).HasComputedColumnSql("N'SO'+CONVERT([nvarchar](23),[SalesOrderID]");
            
            builder.Property(e => e.PurchaseOrderNumber);
            builder.Property(e => e.AccountNumber);

            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("CustomerID").IsRequired();

            builder.Property(e => e.SalesPersonId);
            builder.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");
            
            builder.Property(e => e.TerritoryId);
            builder.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

            builder.Property(e => e.BillToAddressId).IsRequired();
            builder.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");

            builder.Property(e => e.ShipToAddressId).IsRequired();
            builder.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");

            builder.Property(e => e.ShipMethodId).IsRequired();
            builder.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");

            builder.Property(e => e.CreditCardId);
            builder.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

            builder.Property(e => e.CreditCardApprovalCode);
            builder.Property(e => e.CurrencyRateId);
            builder.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");

            builder.Property(e => e.SubTotal).IsRequired();
            builder.Property(e => e.TaxAmt).IsRequired();
            builder.Property(e => e.Freight).IsRequired();
            builder.Property(e => e.TotalDue).HasComputedColumnSql("[SubTotal]+[TaxAmt])+[Freight]");
            
            builder.Property(e => e.Comment);
        }
    }
}