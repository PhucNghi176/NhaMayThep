using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LoaiCongTac.Create;
using NhaMayThep.Application.LoaiCongTac.Delete;
using NhaMayThep.Application.LoaiCongTac.GetAll;
using NhaMayThep.Application.LoaiCongTac.Update;
using NhaMayThep.Application.LoaiCongTac;
using System.Net.Mime;
using NhaMayThep.Application.LichSuCongTacNhanVien;
using NhaMayThep.Application.LichSuCongTacNhanVien.Create;
using NhaMayThep.Application.LichSuCongTacNhanVien.Delete;
using NhaMayThep.Application.LichSuCongTacNhanVien.Update;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetAll;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuCongTacNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public LichSuCongTacNhanVienController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("create")]
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
            return Ok(new JsonResponse<string>("create thành công"));
        }

        [HttpPut("update/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLichSuCongTacNhanVien(
            [FromRoute] string id,
            [FromBody] UpdateLichSuCongTacNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            if(command.ID == default)
            {
                command.ID = id;
            }
            await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>("update thành công"));
        }

        [HttpDelete("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteLichSuCongTacNhanVien(
            [FromBody] DeleteLichSuCongTacNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<string>(result));
        }



        [HttpGet("getAll")]
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

        [HttpGet("getByMasoNV")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByMaSoNhanVien(
            string maSoNhanVienId,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByMaSoNhanVienQuery(maSoNhanVienId), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<LichSuCongTacNhanVienDto>>(result));
        }
    }
}
