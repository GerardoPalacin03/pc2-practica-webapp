using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Events;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Events;

/// <summary>
///     Domain event raised when a new covenant is created.
/// </summary>
/// <param name="DocumentIdentifier">The identifier of the covenant document.</param>
/// <param name="ClientId">The identifier of the client party.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public record CovenantCreatedEvent(CapbaseIdentifier DocumentIdentifier, PartyId ClientId) : IEvent;
