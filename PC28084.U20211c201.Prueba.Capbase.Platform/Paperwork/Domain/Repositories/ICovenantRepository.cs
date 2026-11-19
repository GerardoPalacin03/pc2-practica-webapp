using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Repositories;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Repositories;

/// <summary>
///     Repository contract for the <see cref="Covenant" /> aggregate.
/// </summary>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public interface ICovenantRepository : IBaseRepository<Covenant>
{
    /// <summary>
    ///     Checks whether a covenant with the given document identifier already exists.
    /// </summary>
    /// <param name="documentIdentifier">The document identifier to look for.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if a covenant with that document identifier exists; otherwise, <c>false</c>.</returns>
    Task<bool> ExistsByDocumentIdentifierAsync(CapbaseIdentifier documentIdentifier,
        CancellationToken cancellationToken);
}
