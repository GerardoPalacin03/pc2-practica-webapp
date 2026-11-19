namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

/// <summary>
///     Exception thrown when the value of a monetary amount is lower than zero.
/// </summary>
/// <param name="actualValue">The invalid value that was received.</param>
/// <param name="paramName">The name of the argument that violates the rule.</param>
/// <remarks>
///     Author: Your Full Name
/// </remarks>
public sealed class NegativeMonetaryAmountException(decimal actualValue, string paramName)
    : ArgumentOutOfRangeException(paramName, actualValue,
            "The value of a monetary amount must be greater than or equal to zero."),
        ILocalizableException
{
    /// <inheritdoc />
    public string ResourceKey => "Validation.NegativeMonetaryAmount";
}
