using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Commands;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Events;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Aggregates.Internal;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.ValueObjects;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;

/// <summary>
///     Covenant aggregate root of the Paperwork bounded context.
/// </summary>
/// <remarks>
///     A covenant is a legal agreement identified by a document identifier, signed with a client, valid during a
///     legality period and worth a total monetary amount. The business rules on the period and the amount are
///     enforced by their value objects, so an invalid covenant can never be created.
///     Author: Gerardo Palacin
/// </remarks>
public partial class Covenant : AggregateRoot
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Covenant" /> aggregate. Required by EF Core.
    /// </summary>
    protected Covenant()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Covenant" /> aggregate from a command.
    /// </summary>
    /// <param name="command">The <see cref="CreateCovenantCommand" /> with the data of the covenant.</param>
    /// <exception cref="ArgumentException">
    ///     Thrown when the legality period or the monetary amount violate a business rule.
    /// </exception>
    public Covenant(CreateCovenantCommand command)
    {
        DocumentIdentifier = new CapbaseIdentifier(command.DocumentIdentifier);
        ClientId = new PartyId(command.ClientId);
        Period = new LegalityPeriod(command.PeriodStartDate, command.PeriodEndDate);
        TotalValue = new MonetaryAmount(command.MonetaryAmountValue, command.MonetaryAmountCurrency);
        Status = command.Status ?? CovenantStatus.Draft;
        Footnotes = command.Footnotes;
        AddDomainEvent(new CovenantCreatedEvent(DocumentIdentifier, ClientId));
    }

    /// <summary>
    ///     Gets the unique identifier of the covenant, generated when it is persisted.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    ///     Gets the identifier of the covenant document.
    /// </summary>
    public CapbaseIdentifier DocumentIdentifier { get; private set; }

    /// <summary>
    ///     Gets the identifier of the client party.
    /// </summary>
    public PartyId ClientId { get; private set; }

    /// <summary>
    ///     Gets the legality period of the covenant.
    /// </summary>
    public LegalityPeriod Period { get; private set; } = null!;

    /// <summary>
    ///     Gets the total value of the covenant.
    /// </summary>
    public MonetaryAmount TotalValue { get; private set; } = null!;

    /// <summary>
    ///     Gets the status of the covenant.
    /// </summary>
    public CovenantStatus Status { get; private set; } = CovenantStatus.Draft;

    /// <summary>
    ///     Gets the optional notes about the covenant.
    /// </summary>
    public string? Footnotes { get; private set; }
}
