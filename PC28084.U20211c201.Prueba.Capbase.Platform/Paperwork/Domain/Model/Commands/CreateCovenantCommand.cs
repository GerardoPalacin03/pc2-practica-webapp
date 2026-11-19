using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Commands;

/// <summary>
///     Command that orders the creation of a covenant.
/// </summary>
/// <param name="DocumentIdentifier">The GUID that uniquely identifies the covenant document.</param>
/// <param name="ClientId">The UUID of the client party.</param>
/// <param name="PeriodStartDate">The date on which the legality period starts.</param>
/// <param name="PeriodEndDate">The date on which the legality period ends.</param>
/// <param name="MonetaryAmountValue">The total value of the covenant.</param>
/// <param name="MonetaryAmountCurrency">The currency of the total value.</param>
/// <param name="Status">The status of the covenant. When it is <c>null</c>, the covenant is created as a draft.</param>
/// <param name="Footnotes">Optional notes about the covenant.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public record CreateCovenantCommand(
    Guid DocumentIdentifier,
    Guid ClientId,
    DateOnly PeriodStartDate,
    DateOnly PeriodEndDate,
    decimal MonetaryAmountValue,
    string? MonetaryAmountCurrency,
    CovenantStatus? Status,
    string? Footnotes);
