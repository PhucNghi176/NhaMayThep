using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.LichSuCongTacNhanVien;
using NhaMayThep.Application.LichSuCongTacNhanVien.Create;
using NhaMayThep.Application.LichSuCongTacNhanVien.Delete;
using NhaMayThep.Application.LichSuCongTacNhanVien.FilterLichSuCongTac;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetAll;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetByPagination;
using NhaMayThep.Application.LichSuCongTacNhanVien.Update;
using NhaMayThep.Application.LichSuNghiPhep.GetByPagination;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NhaMayThep.Api.Controllers
{
    
    [ApiController]
    [Authorize]
    public class LichSuCongTacNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public LichSuCongTacNhanVienController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("lich-su-cong-tac-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateLichSuCongTacNhanVien(
           [FromBody] CreateLichSuCongTacNhanVienCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("lich-su-cong-tac-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLichSuCongTacNhanVien(
            [FromBody] UpdateLichSuCongTacNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("lich-su-cong-tac-nhan-vien/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteLichSuCongTacNhanVien(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteLichSuCongTacNhanVienCommand(id), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<string>(result));
        }



        [HttpGet("lich-su-cong-tac-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LichSuCongTacNhanVienDto>>>> GetAllLichSuCongTacNhanVien(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllLichSuCongTacNhanVienQuery(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<List<LichSuCongTacNhanVienDto>>(result));
        }

        [HttpGet("lich-su-cong-tac-nhan-vien/{maSoNhanVienId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByMaSoNhanVien(
          [FromRoute] string maSoNhanVienId,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByMaSoNhanVienQuery(maSoNhanVienId), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<LichSuCongTacNhanVienDto>>(result));
        }

        [HttpGet("lich-su-cong-tac/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>>> GetPagination([FromQuery] GetLichSuCongTacNhanVienByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("lich-su-cong-tac/filter-lich-su-cong-tac")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuCongTacNhanVienDto>>>> Filter(
            [FromQuery] FilterLichSuCongTacQuery query, 
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
