﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.HopDong;
using NhaMayThep.Application.HopDong.CreateHopDongWithExcel;
using NhaMayThep.Application.HopDong.CreateNewHopDongCommand;
using NhaMayThep.Application.HopDong.DeleteHopDongCommand;
using NhaMayThep.Application.HopDong.FilterHopDong;
using NhaMayThep.Application.HopDong.GetHopDongByIdQuery;
using NhaMayThep.Application.HopDong.UpdateHopDongCommand;
using NhaMayThep.Application.HopDong.UpdateNgayKetThucHopDongCommand;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.HopDong
{
    [ApiController]
    
    public class HopDongController : ControllerBase
    {
        private readonly ISender _mediator;
        public HopDongController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("hop-dong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewHopDong([FromBody] CreateNewHopDongCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("hop-dong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> RemoveHopDong([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteHopDongCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        //[HttpGet("hop-dong")]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(JsonResponse<List<HopDongDto>>), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(JsonResponse<List<HopDongDto>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<JsonResponse<List<HopDongDto>>>> GetAll(CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(new GetAllHopDongQuery(), cancellationToken);
        //    return Ok(new JsonResponse<List<HopDongDto>>(result));
        //}

        [HttpGet("hop-dong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<HopDongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<HopDongDto>>> GetById([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHopDongByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<HopDongDto>(result));
        }

        [HttpPut("hop-dong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateHopDong([FromBody] UpdateHopDongCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPost("hop-dong/file")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ReadFile(IFormFile[] file, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new CreateHopDongWithExcelCommand(file), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        //[HttpGet("hop-dong/phan-trang")]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(JsonResponse<PagedResult<HopDongDto>>), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(JsonResponse<PagedResult<HopDongDto>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<JsonResponse<PagedResult<HopDongDto>>>> GetPagination([FromQuery] GetHopDongByPaginationQuery query, CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(query, cancellationToken);
        //    return Ok(result);
        //}

        [HttpPut("hop-dong/thay-doi-ngay-ket-thuc")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<HopDongDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<HopDongDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateNgayKetThuc([FromBody] UpdateNgayKetThucHopDongCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("hop-dong/filter-hop-dong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<HopDongDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<HopDongDto>>>> FilterNhanVien(
        [FromQuery] FilterHopDongQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
