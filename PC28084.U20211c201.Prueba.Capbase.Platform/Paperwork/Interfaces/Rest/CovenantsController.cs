using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Application.CommandServices;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Resources;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest.Transform;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Interfaces.Rest.ProblemDetails;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Interfaces.Rest;

/// <summary>
///     REST controller that exposes the covenants endpoint (<c>/api/v1/covenants</c>).
/// </summary>
/// <param name="covenantCommandService">The covenant command service.</param>
/// <param name="problemDetailsFactory">The factory used to build localized problem details.</param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Covenants")]
public class CovenantsController(
    ICovenantCommandService covenantCommandService,
    ProblemDetailsFactory problemDetailsFactory)
    : ControllerBase
{
    /// <summary>
    ///     Creates a covenant.
    /// </summary>
    /// <param name="resource">The data of the covenant to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     HTTP 201 with the created covenant, including its generated id; HTTP 400 when a business rule is
    ///     violated; HTTP 409 when a covenant with the same document identifier already exists.
    /// </returns>
    [HttpPost]
    [EndpointSummary("Create a covenant")]
    [EndpointDescription(
        "Creates a covenant. The id is generated when the covenant is stored. The status is Draft when it is not specified.")]
    [ProducesResponseType(typeof(CovenantResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateCovenant([FromBody] CreateCovenantResource resource,
        CancellationToken cancellationToken)
    {
        var createCovenantCommand = CreateCovenantCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await covenantCommandService.Handle(createCovenantCommand, cancellationToken);

        return PaperworkActionResultAssembler.ToActionResultFromCreateCovenantResult(
            this,
            result,
            problemDetailsFactory,
            createdCovenant => StatusCode(StatusCodes.Status201Created,
                CovenantResourceFromEntityAssembler.ToResourceFromEntity(createdCovenant))
        );
    }
}
