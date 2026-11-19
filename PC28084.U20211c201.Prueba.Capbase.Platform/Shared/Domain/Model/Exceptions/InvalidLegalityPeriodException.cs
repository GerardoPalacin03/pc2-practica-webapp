namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

/// <summary>
///     Exception thrown when the end date of a legality period is not later than its start date.
/// </summary>
/// <param name="paramName">The name of the argument that violates the rule.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public sealed class InvalidLegalityPeriodException(string paramName)
    : ArgumentException("The end date of a legality period must be later than its start date.", paramName),
        ILocalizableException
{
    /// <inheritdoc />
    public string ResourceKey => "Validation.InvalidLegalityPeriod";
}
