namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

/// <summary>
///     Exception thrown when the currency of a monetary amount is null or blank.
/// </summary>
/// <param name="paramName">The name of the argument that violates the rule.</param>
/// <remarks>
///     Author: Your Full Name
/// </remarks>
public sealed class BlankCurrencyException(string paramName)
    : ArgumentNullException(paramName, "The currency of a monetary amount must not be null or blank."),
        ILocalizableException
{
    /// <inheritdoc />
    public string ResourceKey => "Validation.BlankCurrency";
}
