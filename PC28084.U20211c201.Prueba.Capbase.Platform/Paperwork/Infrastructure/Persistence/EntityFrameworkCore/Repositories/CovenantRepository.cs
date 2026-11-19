using Microsoft.EntityFrameworkCore;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Repositories;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     EF Core implementation of the <see cref="ICovenantRepository" />.
/// </summary>
/// <param name="context">The database context.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public class CovenantRepository(AppDbContext context) : BaseRepository<Covenant>(context), ICovenantRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsByDocumentIdentifierAsync(CapbaseIdentifier documentIdentifier,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Covenant>()
            .AnyAsync(covenant => covenant.DocumentIdentifier == documentIdentifier, cancellationToken);
    }
}
