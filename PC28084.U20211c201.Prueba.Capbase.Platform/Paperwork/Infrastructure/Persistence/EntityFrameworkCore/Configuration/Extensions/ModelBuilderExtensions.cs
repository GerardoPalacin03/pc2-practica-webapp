using Microsoft.EntityFrameworkCore;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.ValueConverters;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     Fluent API configuration of the Paperwork bounded context.
/// </summary>
/// <remarks>
///     The persistence concepts are kept here, apart from the domain aggregates.
///     Author: Gerardo Palacin
/// </remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the persistence configuration of the Paperwork bounded context.
    /// </summary>
    /// <param name="builder">The model builder of the database context.</param>
    public static void ApplyPaperworkConfiguration(this ModelBuilder builder)
    {
        // Covenant aggregate
        builder.Entity<Covenant>().HasKey(c => c.Id);
        builder.Entity<Covenant>().Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<Covenant>().Property(c => c.DocumentIdentifier)
            .HasConversion(new StronglyTypedIdConverter<CapbaseIdentifier, Guid>(id => id.Value,
                value => new CapbaseIdentifier(value)))
            .IsRequired();
        builder.Entity<Covenant>().HasIndex(c => c.DocumentIdentifier)
            .IsUnique()
            .HasDatabaseName("ux_covenants_document_identifier");

        builder.Entity<Covenant>().Property(c => c.ClientId)
            .HasConversion(new StronglyTypedIdConverter<PartyId, Guid>(id => id.Value, value => new PartyId(value)))
            .IsRequired();

        builder.Entity<Covenant>().OwnsOne(c => c.Period,
            p =>
            {
                p.WithOwner().HasForeignKey("Id");
                p.Property(period => period.StartDate)
                    .HasColumnName("PeriodStartDate")
                    .HasConversion(date => date.ToDateTime(TimeOnly.MinValue),
                        dateTime => DateOnly.FromDateTime(dateTime))
                    .IsRequired();
                p.Property(period => period.EndDate)
                    .HasColumnName("PeriodEndDate")
                    .HasConversion(date => date.ToDateTime(TimeOnly.MinValue),
                        dateTime => DateOnly.FromDateTime(dateTime))
                    .IsRequired();
            });
        builder.Entity<Covenant>().Navigation(c => c.Period).IsRequired();

        builder.Entity<Covenant>().OwnsOne(c => c.TotalValue,
            m =>
            {
                m.WithOwner().HasForeignKey("Id");
                m.Property(amount => amount.Value)
                    .HasColumnName("TotalValue")
                    .HasPrecision(18, 2)
                    .IsRequired();
                m.Property(amount => amount.Currency)
                    .HasColumnName("TotalValueCurrency")
                    .HasMaxLength(10)
                    .IsRequired();
            });
        builder.Entity<Covenant>().Navigation(c => c.TotalValue).IsRequired();

        builder.Entity<Covenant>().Property(c => c.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.Entity<Covenant>().Property(c => c.Footnotes)
            .HasMaxLength(1000)
            .IsRequired(false);
    }
}
