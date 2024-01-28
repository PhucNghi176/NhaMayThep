﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap;
using NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById;
using NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThongTinPhuCap
{
    [ApiController]
    [Authorize]
    public class ThongTinPhuCapController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinPhuCapController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("thong-tin-phu-cap")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewThongTinPhuCap([FromBody] CreateNewPhuCapCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewThongTinPhuCap), new { id = result }, new JsonResponse<string>(result));
        }

        [HttpDelete("thong-tin-phu-cap/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RemoveThongTinPhuCap([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeletePhuCapCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-phu-cap")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<PhuCapDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<PhuCapDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhuCapDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllPhuCapQuery(), cancellationToken);
            return Ok(new JsonResponse<List<PhuCapDto>>(result));
        }

        [HttpGet("thong-tin-phu-cap/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhuCapDto>>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPhuCapByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<PhuCapDto>(result));
        }
        [HttpPut("thong-tinphu-cap")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PhuCapDto>>> UpdateThongTinPhuCap([FromBody] UpdatePhuCapCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<PhuCapDto>(result));
        }
    }
}