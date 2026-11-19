using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.ValueObjects;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;

/// <summary>
///     Value object that uniquely identifies a covenant document across Capbase.
/// </summary>
/// <param name="Value">
///     The GUID that identifies the document. It is generated in another bounded context.
/// </param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public readonly record struct CapbaseIdentifier(Guid Value) : IEntityId<Guid>
{
    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString();
    }
}
