using System.Globalization;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Resources;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Transform;

/// <summary>
///     Assembler that transforms a <see cref="Covenant" /> aggregate into a <see cref="CovenantResource" />.
/// </summary>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public static class CovenantResourceFromEntityAssembler
{
    private const string DateFormat = "yyyy-MM-dd";

    /// <summary>
    ///     Converts a <see cref="Covenant" /> to its <see cref="CovenantResource" /> representation.
    /// </summary>
    /// <param name="entity">The covenant aggregate. It must not be null.</param>
    /// <returns>A <see cref="CovenantResource" /> that represents the covenant.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="entity" /> is null.</exception>
    public static CovenantResource ToResourceFromEntity(Covenant entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new CovenantResource(
            entity.Id,
            entity.DocumentIdentifier.Value.ToString(),
            entity.ClientId.Value.ToString(),
            entity.Period.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
            entity.Period.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
            entity.TotalValue.Value,
            entity.TotalValue.Currency,
            entity.Status.ToString(),
            entity.Footnotes);
    }
}
