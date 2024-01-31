using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.CanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanById;
using NhaMayThep.Application.CanCuocCongDan.GetPagination;
using NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanByNhanVienID;
using NhaMayThep.Application.CanCuocCongDan.UpdateCanCuocCongDan;
using NhaMayThep.Application.Common.Interfaces;
using System.Net.Mime;
using System.Security.Claims;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class CanCuocCongCanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CanCuocCongCanController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;

        }

        [HttpGet]
        [Route("can-cuoc-cong-dan")]
        [ProducesResponseType(typeof(JsonResponse<CanCuocCongDanDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CanCuocCongDanDto>>> GetCanCuocCongDanById(
                       [FromQuery] GetCanCuocCongDanByIdQuery query,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<CanCuocCongDanDto>(result));
        }

        [HttpPost]
        [Route("can-cuoc-cong-dan")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewCanCuocCongDan(
                       [FromBody] CreateNewCanCuocCongDanCommand command,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete]
        [Route("can-cuoc-cong-dan")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteCanCuocCongDan(
                                  [FromQuery] DeleteCanCuocCongDanCommand command,
                                                                   CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut]
        [Route("can-cuoc-cong-dan")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateCanCuocCongDan(
            [FromBody] UpdateCanCuocCongDanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));

        }

        [HttpGet("CanCuocCongDan/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CanCuocCongDanDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CanCuocCongDanDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CanCuocCongDanDto>>>> GetPagination([FromQuery] GetCCCDByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        [HttpGet]
        [Route("can-cuoc-cong-dan/get-by-nhan-vien-id")]
        [ProducesResponseType(typeof(JsonResponse<CanCuocCongDanDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CanCuocCongDanDto>>> GetCanCuocCongDanByNhanVienID(
                                  [FromQuery] GetCanCuocCongDanByNhanVienIDQuery query,
                                                                   CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<CanCuocCongDanDto>(result));
        }
    }
}
