﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using NhaMayThep.Application.LichSuNghiPhep.Create;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep.GetAll;
using NhaMayThep.Application.LichSuNghiPhep.GetByID;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.LichSuNghiPhep;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichSuNghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public LichSuNghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep created successfully"));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteLichSuNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep deleted successfully"));
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep updated successfully"));
        }


        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LichSuNghiPhepDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllLichSuNghiPhepQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<LichSuNghiPhepDto>>(result));
        }

        [HttpGet("getById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LichSuNghiPhepDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<LichSuNghiPhepDto>(result));
        }
    }
}