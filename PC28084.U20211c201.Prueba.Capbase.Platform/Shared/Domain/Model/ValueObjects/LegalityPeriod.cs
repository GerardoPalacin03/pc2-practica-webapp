using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.ValueObjects;

/// <summary>
///     Value object that represents the period in which a legal document is valid.
/// </summary>
/// <remarks>
///     The period is valid only when the end date is later than the start date.
///     Author: Your Full Name
/// </remarks>
public record LegalityPeriod
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LegalityPeriod" /> value object.
    /// </summary>
    /// <param name="startDate">The date on which the period starts.</param>
    /// <param name="endDate">The date on which the period ends. It must be later than <paramref name="startDate" />.</param>
    /// <exception cref="InvalidLegalityPeriodException">
    ///     Thrown when <paramref name="endDate" /> is lower than or equal to <paramref name="startDate" />.
    /// </exception>
    public LegalityPeriod(DateOnly startDate, DateOnly endDate)
    {
        if (endDate <= startDate) throw new InvalidLegalityPeriodException(nameof(endDate));

        StartDate = startDate;
        EndDate = endDate;
    }

    /// <summary>
    ///     Gets the date on which the period starts.
    /// </summary>
    public DateOnly StartDate { get; private set; }

    /// <summary>
    ///     Gets the date on which the period ends.
    /// </summary>
    public DateOnly EndDate { get; private set; }

    /// <summary>
    ///     Determines whether the period is expired at the given date.
    /// </summary>
    /// <param name="checkDate">The date to check against the end of the period.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="checkDate" /> is later than <see cref="EndDate" />; otherwise, <c>false</c>.
    /// </returns>
    public bool IsExpired(DateOnly checkDate)
    {
        return checkDate > EndDate;
    }
}
