using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Commands;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Resources;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Transform;

/// <summary>
///     Assembler that transforms a <see cref="CreateCovenantResource" /> into a <see cref="CreateCovenantCommand" />.
/// </summary>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public static class CreateCovenantCommandFromResourceAssembler
{
    /// <summary>
    ///     Converts a <see cref="CreateCovenantResource" /> to a <see cref="CreateCovenantCommand" />.
    /// </summary>
    /// <param name="resource">The resource received by the API. It must not be null.</param>
    /// <returns>A new <see cref="CreateCovenantCommand" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="resource" /> is null.</exception>
    public static CreateCovenantCommand ToCommandFromResource(CreateCovenantResource resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        return new CreateCovenantCommand(
            resource.DocumentIdentifier,
            resource.ClientId,
            resource.PeriodStartDate,
            resource.PeriodEndDate,
            resource.MonetaryAmountValue,
            resource.MonetaryAmountCurrency,
            resource.Status,
            resource.Footnotes);
    }
}
