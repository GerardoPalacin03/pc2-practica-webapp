namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Resources;

/// <summary>
///     Resource returned by the REST API to represent a covenant.
/// </summary>
/// <param name="Id">The generated identifier of the covenant.</param>
/// <param name="DocumentId">The identifier of the covenant document.</param>
/// <param name="ClientId">The identifier of the client party.</param>
/// <param name="PeriodStartDate">The date on which the legality period starts (yyyy-MM-dd).</param>
/// <param name="PeriodEndDate">The date on which the legality period ends (yyyy-MM-dd).</param>
/// <param name="MonetaryAmountValue">The total value of the covenant.</param>
/// <param name="MonetaryAmountCurrency">The currency of the total value.</param>
/// <param name="Status">The status of the covenant.</param>
/// <param name="Footnotes">The optional notes about the covenant.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public record CovenantResource(
    int Id,
    string DocumentId,
    string ClientId,
    string PeriodStartDate,
    string PeriodEndDate,
    decimal MonetaryAmountValue,
    string MonetaryAmountCurrency,
    string Status,
    string? Footnotes);
