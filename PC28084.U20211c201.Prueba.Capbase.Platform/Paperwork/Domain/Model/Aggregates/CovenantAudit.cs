using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Entities;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;

/// <summary>
///     Audit part of the <see cref="Covenant" /> aggregate.
/// </summary>
/// <remarks>
///     The timestamps are filled automatically by the <c>AuditableEntityInterceptor</c> when the aggregate is saved.
///     Author: Gerardo Palacin
/// </remarks>
public partial class Covenant : IAuditableEntity
{
    /// <inheritdoc />
    public DateTimeOffset? CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? UpdatedAt { get; set; }
}
