﻿
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.TrinhDoHocVan.Commands;
using NhaMayThep.Application.TrinhDoHocVan.Delete;
using NhaMayThep.Application.TrinhDoHocVan;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.TrinhDoHocVan.GetById;
using NhaMayThep.Application.TrinhDoHocVan.GetAll;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class TrinhDoHocVanController : ControllerBase
    {
        private readonly ISender _mediator;

        public TrinhDoHocVanController(ISender mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("trinh-do-hoc-van")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateTrinhDoHocVan(
            [FromBody] CreateTrinhDoHocVanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("trinh-do-hoc-van/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteTrinhDoHocVan(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteTrinhDoHocVanCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpPut("trinh-do-hoc-van")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateTrinhDoHocVan(
        [FromBody] UpdateTrinhDoHocVanCommand command,
        CancellationToken cancellationToken = default)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return new JsonResponse<string>("Thành Công!");
            }
            catch (Exception)
            {
                return BadRequest(new JsonResponse<string>("Thất Bại!"));
            }
        }


        [HttpGet("trinh-do-hoc-van/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<TrinhDoHocVanDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<TrinhDoHocVanDto>>> GetTrinhDoHocVanById(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdQuery(id), cancellationToken);
            return new JsonResponse<TrinhDoHocVanDto>(result);
        }

        [HttpGet("trinh-do-hoc-van")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<TrinhDoHocVanDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<TrinhDoHocVanDto>>>> GetTrinhDoHocVans(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return new JsonResponse<List<TrinhDoHocVanDto>>(result);
        }
    }
}
