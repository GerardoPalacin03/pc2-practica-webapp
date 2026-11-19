using Microsoft.AspNetCore.Mvc;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Domain.Model.Aggregates;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Application.Model;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Domain.Model.Errors;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Interfaces.Rest.ProblemDetails;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Transform;

/// <summary>
///     Assembler that transforms the results of the Paperwork application services into HTTP action results.
/// </summary>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public static class PaperworkActionResultAssembler
{
    /// <summary>
    ///     Converts the result of creating a covenant into an action result.
    /// </summary>
    /// <param name="controller">The controller that produces the response.</param>
    /// <param name="result">The result returned by the command service.</param>
    /// <param name="problemDetailsFactory">The factory used to build localized problem details on failure.</param>
    /// <param name="successAction">The function that builds the response when the result is successful.</param>
    /// <returns>
    ///     The response built by <paramref name="successAction" /> on success; otherwise, a problem details response
    ///     with the HTTP status that matches the error type.
    /// </returns>
    public static IActionResult ToActionResultFromCreateCovenantResult(
        ControllerBase controller,
        Result<Covenant> result,
        ProblemDetailsFactory problemDetailsFactory,
        Func<Covenant, IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction(result.Value!);

        var error = result.DomainError;
        return problemDetailsFactory.CreateProblemDetails(
            controller,
            ToStatusCodeFromErrorType(error.Type),
            error.Type.ToString(),
            error.Code);
    }

    private static int ToStatusCodeFromErrorType(EErrorType errorType)
    {
        return errorType switch
        {
            EErrorType.Validation => StatusCodes.Status400BadRequest,
            EErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            EErrorType.Forbidden => StatusCodes.Status403Forbidden,
            EErrorType.NotFound => StatusCodes.Status404NotFound,
            EErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
