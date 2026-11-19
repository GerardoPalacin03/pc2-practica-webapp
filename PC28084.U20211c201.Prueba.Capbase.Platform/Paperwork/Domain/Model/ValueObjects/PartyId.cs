using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.ValueObjects;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;

/// <summary>
///     Value object that identifies a party (for example, a client) that takes part in a covenant.
/// </summary>
/// <param name="Value">
///     The UUID that identifies the party. It originates in another bounded context.
/// </param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public readonly record struct PartyId(Guid Value) : IEntityId<Guid>
{
    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString();
    }
}
