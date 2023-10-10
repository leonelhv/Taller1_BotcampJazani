using Jazani.Domain.Mc.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Mc.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AmountInvested).HasColumnName("amountinvestd").HasColumnType("decimal");
            builder.Property(t => t.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(t => t.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(t => t.CurrencyTypeId).HasColumnName("currencytypeid");

            builder.Property(t => t.InvestmentconceptId).HasColumnName("investmentconceptid");
            builder.Property(t => t.MeasureunitId).HasColumnName("measureunitid");
            builder.Property(t => t.PeriodtypeId).HasColumnName("periodtypeid");

            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.HolderId).HasColumnName("holderid");
            builder.Property(t => t.State).HasColumnName("state");
            builder.Property(t => t.DeclaredTypeId).HasColumnName("declaredtypeid");

            builder.HasOne(t => t.Holder)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.HolderId);

            builder.HasOne(t => t.Investmentconcept)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.InvestmentconceptId);

            builder.HasOne(t => t.Investmenttype)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.InvestmentTypeId);

            builder.HasOne(t => t.MeasureUnit)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.MeasureunitId);

            builder.HasOne(t => t.MiningConcession)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.MiningConcessionId);

            builder.HasOne(t => t.PeriodType)
                .WithMany(m => m.Investments)
                .HasForeignKey(t => t.PeriodtypeId);


        }
    }
}
