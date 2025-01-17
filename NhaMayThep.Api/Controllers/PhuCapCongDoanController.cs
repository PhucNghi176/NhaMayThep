﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.PhuCapCongDoan;
using NhaMayThep.Application.PhuCapCongDoan.Create;
using NhaMayThep.Application.PhuCapCongDoan.Delete;
using NhaMayThep.Application.PhuCapCongDoan.GetAll;
using NhaMayThep.Application.PhuCapCongDoan.GetId;
using NhaMayThep.Application.PhuCapCongDoan.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class PhuCapCongDoanController : ControllerBase
    {
        private readonly ISender _mediator;

        public PhuCapCongDoanController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("phu-cap-cong-doan")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreatePhuCapCongDoan([FromBody] CreatePhuCapCongDoanCommand command, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("phu-cap-cong-doan/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeletePhuCapCongDoan(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeletePhuCapCongDoanCommand(id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpPut("phu-cap-cong-doan")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdatePhuCapCongDoan(
            [FromBody] UpdatePhuCapCongDoanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpGet("phu-cap-cong-doan")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhuCapCongDoanDto>>>> GetAllPhuCapCongDoan(CancellationToken cancellationToken)
        {
            var query = new GetAllPhuCapCongDoanQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<List<PhuCapCongDoanDto>>(result);
        }

        [HttpGet("phu-cap-cong-doan/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PhuCapCongDoanDto>>> GetPhuCapCongDoanById(string id, CancellationToken cancellationToken)
        {
            var query = new GetPhuCapCongDoanByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<PhuCapCongDoanDto>(result);
        }
    }
}
