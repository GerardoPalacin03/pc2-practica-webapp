using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Resources;

/// <summary>
///     Resource received by the REST API to create a covenant.
/// </summary>
/// <param name="DocumentIdentifier">The GUID that uniquely identifies the covenant document.</param>
/// <param name="ClientId">The UUID of the client party.</param>
/// <param name="PeriodStartDate">The date on which the legality period starts (yyyy-MM-dd).</param>
/// <param name="PeriodEndDate">The date on which the legality period ends (yyyy-MM-dd).</param>
/// <param name="MonetaryAmountValue">The total value of the covenant.</param>
/// <param name="MonetaryAmountCurrency">The currency of the total value.</param>
/// <param name="Status">The optional status of the covenant: Draft (default), Active or Expired.</param>
/// <param name="Footnotes">Optional notes about the covenant.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public record CreateCovenantResource(
    Guid DocumentIdentifier,
    Guid ClientId,
    DateOnly PeriodStartDate,
    DateOnly PeriodEndDate,
    decimal MonetaryAmountValue,
    string? MonetaryAmountCurrency,
    CovenantStatus? Status,
    string? Footnotes);
