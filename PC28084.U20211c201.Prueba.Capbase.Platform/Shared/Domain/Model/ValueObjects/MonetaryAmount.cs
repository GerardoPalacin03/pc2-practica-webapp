using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.ValueObjects;

/// <summary>
///     Value object that represents an amount of money in a given currency.
/// </summary>
/// <remarks>
///     The value cannot be negative and the currency cannot be null or blank.
///     Author: Gerardo Palacin
/// </remarks>
public record MonetaryAmount
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MonetaryAmount" /> value object.
    /// </summary>
    /// <param name="value">The amount of money. It must be greater than or equal to zero.</param>
    /// <param name="currency">The currency of the amount. It must not be null or blank.</param>
    /// <exception cref="NegativeMonetaryAmountException">Thrown when <paramref name="value" /> is lower than zero.</exception>
    /// <exception cref="BlankCurrencyException">Thrown when <paramref name="currency" /> is null or blank.</exception>
    public MonetaryAmount(decimal value, string? currency)
    {
        if (value < decimal.Zero) throw new NegativeMonetaryAmountException(value, nameof(value));
        if (string.IsNullOrWhiteSpace(currency)) throw new BlankCurrencyException(nameof(currency));

        Value = value;
        Currency = currency;
    }

    /// <summary>
    ///     Gets the amount of money.
    /// </summary>
    public decimal Value { get; private set; }

    /// <summary>
    ///     Gets the currency of the amount.
    /// </summary>
    public string Currency { get; private set; }

    /// <summary>
    ///     Multiplies the value of the amount by a factor.
    /// </summary>
    /// <param name="factor">The factor to multiply the value by.</param>
    /// <returns>A new <see cref="MonetaryAmount" /> with the resulting value and the same currency.</returns>
    /// <exception cref="NegativeMonetaryAmountException">Thrown when the resulting value is lower than zero.</exception>
    public MonetaryAmount Multiply(decimal factor)
    {
        return new MonetaryAmount(Value * factor, Currency);
    }
}
