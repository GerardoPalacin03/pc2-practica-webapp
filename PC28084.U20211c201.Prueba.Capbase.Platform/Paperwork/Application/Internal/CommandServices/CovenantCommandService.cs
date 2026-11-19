using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Application.CommandServices;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Commands;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Errors;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Repositories;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Application.Model;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Repositories;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Application.Internal.CommandServices;

/// <summary>
///     Command service that orchestrates the creation of covenants.
/// </summary>
/// <param name="covenantRepository">The covenant repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
/// <remarks>
///     This service only coordinates: the business rules on the period and the amount live in the domain.
///     Author: Gerardo Palacin
/// </remarks>
public class CovenantCommandService(
    ICovenantRepository covenantRepository,
    IUnitOfWork unitOfWork)
    : ICovenantCommandService
{
    /// <inheritdoc />
    public async Task<Result<Covenant>> Handle(CreateCovenantCommand command, CancellationToken cancellationToken)
    {
        Covenant covenant;

        try
        {
            covenant = new Covenant(command);
        }
        catch (ArgumentException exception)
        {
            return Result<Covenant>.Failure(PaperworkErrors.FromArgumentException(exception));
        }

        if (await covenantRepository.ExistsByDocumentIdentifierAsync(covenant.DocumentIdentifier, cancellationToken))
            return Result<Covenant>.Failure(PaperworkErrors.DuplicateDocumentIdentifier);

        await covenantRepository.AddAsync(covenant, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<Covenant>.Success(covenant);
    }
}
