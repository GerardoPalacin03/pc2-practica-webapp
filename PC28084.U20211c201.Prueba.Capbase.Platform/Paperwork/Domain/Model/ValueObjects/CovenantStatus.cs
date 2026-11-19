namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.ValueObjects;

/// <summary>
///     Represents the lifecycle status of a covenant.
/// </summary>
/// <remarks>
///     <see cref="Draft" /> is the default status of a covenant when none is specified.
///     Author: Gerardo Palacin
/// </remarks>
public enum CovenantStatus
{
    /// <summary>
    ///     The covenant is being prepared and is not in force yet. This is the default status.
    /// </summary>
    Draft = 0,

    /// <summary>
    ///     The covenant is in force.
    /// </summary>
    Active = 1,

    /// <summary>
    ///     The covenant is no longer in force.
    /// </summary>
    Expired = 2
}
