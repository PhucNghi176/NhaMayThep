﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.LichSuNghiPhep.Create;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep.FilterLichSuNghiPhep;
using NhaMayThep.Application.LichSuNghiPhep.GetAll;
using NhaMayThep.Application.LichSuNghiPhep.GetByID;
using NhaMayThep.Application.LichSuNghiPhep.GetByPagination;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class LichSuNghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public LichSuNghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep tạo thành công "));
        }

        [HttpDelete("lich-su-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteLichSuNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep xóa thành công "));
        }

        [HttpPut("lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Lich Su Nghi Phep cập nhật thành công"));
        }


        [HttpGet("lich-su-nghi-phep")]
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

        [HttpGet("lich-su-nghi-phep/{id}")]
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

        [HttpGet("lich-su-nghi-phep/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuNghiPhepDto>>>> GetPagination([FromQuery] GetLichSuNghiPhepByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("lich-su-nghi-phep/filter-lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuNghiPhepDto>>>> FilterLichSuNghiPhep(
          [FromQuery] FilterLichSuNghiPhepQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}