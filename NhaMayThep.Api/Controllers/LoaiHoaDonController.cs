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
using NhaMayThep.Application.LoaiHoaDon;
using NhaMayThep.Application.LoaiHoaDon.Create;
using NhaMayThep.Application.LoaiHoaDon.Update;
using NhaMayThep.Application.LoaiHoaDon.Delete;
using NhaMayThep.Application.LoaiHoaDon.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHoaDonController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoaiHoaDonController(ISender mediator)
        {
            _mediator = mediator;
        }


        //[HttpPost("create")]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(JsonResponse<LoaiHoaDonDto>), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<JsonResponse<LoaiHoaDonDto>>> CreateReview(
        //   [FromBody] CreateLoaiHoaDonCommand command,
        //   CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(command, cancellationToken);
        //    //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
        //    return Ok(new JsonResponse<LoaiHoaDonDto>(result));
        //}

        [HttpPost("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoaiHoaDonDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiCongTacDto>>> UpdateReview(
            [FromBody] UpdateLoaiHoaDonCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<LoaiHoaDonDto>(result));
        }

        [HttpPost("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteReview(
            [FromBody] DeleteLoaiHoaDonCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<bool>(result));
        }



        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<LoaiHoaDonDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiHoaDonDto>>>> GetAllReview(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllLoaiHoaDonQuerry(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<List<LoaiHoaDonDto>>(result));
        }
    }
}
