using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Events;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Application.Internal.EventHandlers;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for <see cref="CovenantCreatedEvent" />.
/// </summary>
/// <param name="logger">The logger.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public class CovenantCreatedEventHandler(ILogger<CovenantCreatedEventHandler> logger)
    : IEventHandler<CovenantCreatedEvent>
{
    /// <inheritdoc />
    public Task Handle(CovenantCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Covenant created: document {DocumentIdentifier} for client {ClientId}",
            domainEvent.DocumentIdentifier.Value, domainEvent.ClientId.Value);

        return Task.CompletedTask;
    }
}
