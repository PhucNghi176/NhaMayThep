﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.LoaiNghiPhep;
using NhaMayThep.Application.LoaiNghiPhep.Create;
using NhaMayThep.Application.LoaiNghiPhep.Delete;
using NhaMayThep.Application.LoaiNghiPhep.GetAll;
using NhaMayThep.Application.LoaiNghiPhep.GetById;
using NhaMayThep.Application.LoaiNghiPhep.GetByPagination;
using NhaMayThep.Application.LoaiNghiPhep.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class LoaiNghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoaiNghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("loai-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(CreateLoaiNghiPhepCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("loai-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteLoaiNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }



        [HttpPut("loai-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdateLoaiNghiPhepCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("loai-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiNghiPhepDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<LoaiNghiPhepDto>>(result));
        }

        [HttpGet("loai-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiNghiPhepDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLoaiNghiPhepByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<LoaiNghiPhepDto>(result));
        }

        [HttpGet("loai-nghi-phep/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LoaiNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LoaiNghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LoaiNghiPhepDto>>>> GetPagination([FromQuery] GetLoaiNghiPhepByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
