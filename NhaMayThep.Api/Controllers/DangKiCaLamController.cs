﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.DangKiCaLam.Create;
using NhaMayThep.Application.DangKiCaLam.Delete;
using NhaMayThep.Application.DangKiCaLam.Update;
using NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DangKiCaLam.GetAll;
using NhaMayThep.Application.DangKiCaLam;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DangKiCaLamController : ControllerBase
    {
        private readonly ISender _mediator;

        public DangKiCaLamController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<DangKiCaLamDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<DangKiCaLamDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllDangKiCaLamQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<DangKiCaLamDto>>(result));
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateDangKiCaLamCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí ca làm tạo thành công."));
        }

        [HttpDelete("{maCaLamViec}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(int maCaLamViec, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteDangKiCaLamCommand(maCaLamViec), cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí ca làm xóa thành công."));
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateDangKiCaLamCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí ca làm cập nhật thành công."));
        }

        [HttpGet("{maCaLamViec}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<DangKiCaLamDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<DangKiCaLamDto>>> GetById(int maCaLamViec, CancellationToken cancellationToken = default)
        {
            var query = new GetDangKiCaLamByIdQuery (maCaLamViec);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<DangKiCaLamDto>(result));
        }
    }
}