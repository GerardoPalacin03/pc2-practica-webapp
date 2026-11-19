using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Errors;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Exceptions;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Errors;

/// <summary>
///     Catalog of the errors of the Paperwork bounded context.
/// </summary>
/// <remarks>
///     The error code doubles as the resource key used to localize the error detail.
///     Author: Gerardo Palacin
/// </remarks>
public static class PaperworkErrors
{
    /// <summary>
    ///     Error returned when a covenant with the same document identifier is already registered.
    /// </summary>
    public static readonly Error DuplicateDocumentIdentifier =
        Error.Conflict("Paperwork.DuplicateDocumentIdentifier",
            "A covenant with the same document identifier already exists.");

    /// <summary>
    ///     Generic error returned when the covenant data violates an argument rule without a specific resource key.
    /// </summary>
    public static readonly Error InvalidCovenantData =
        Error.Validation("Paperwork.InvalidCovenantData", "The covenant data is invalid.");

    /// <summary>
    ///     Creates a validation error from an argument exception thrown by the domain.
    /// </summary>
    /// <param name="exception">The exception thrown while applying a business rule.</param>
    /// <returns>
    ///     A validation <see cref="Error" />. When the exception exposes a resource key, it is used as the error code.
    /// </returns>
    public static Error FromArgumentException(ArgumentException exception)
    {
        var code = exception is ILocalizableException localizableException
            ? localizableException.ResourceKey
            : InvalidCovenantData.Code;

        return Error.Validation(code, exception.Message);
    }
}
