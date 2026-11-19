using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Commands;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Application.Model;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Application.CommandServices;

/// <summary>
///     Command service contract for the <see cref="Covenant" /> aggregate.
/// </summary>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public interface ICovenantCommandService
{
    /// <summary>
    ///     Handles the <see cref="CreateCovenantCommand" />.
    /// </summary>
    /// <param name="command">The command with the data of the covenant to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A <see cref="Result{T}" /> with the created <see cref="Covenant" />, or with the error that prevented its
    ///     creation.
    /// </returns>
    Task<Result<Covenant>> Handle(CreateCovenantCommand command, CancellationToken cancellationToken);
}
