using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinGiamTru;
using NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru;
using NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru;
using NhaMayThep.Application.ThongTinGiamTru.GetAllThongTinGiamTru;
using NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById;
using NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    public class ThongTinGiamTruController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ThongTinGiamTruController(IMediator mediator) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("Thong-Tin-Giam-Tru")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruDTO>>>> GetAllThongTinGiamTru(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinGiamTruQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruDTO>>(result));
        }
        [HttpGet]
        [Route("Thong-Tin-Giam-Tru/{Id}")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinGiamTruDTO>> GetByID(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinGiamTruByIdQuery(Id), cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruDTO>(result));
        }
        [HttpPost]
        [Route("Thong-Tin-Giam-Tru")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinGiamTruDTO>> CreateNewThongTinGiamTru(
            [FromBody] CreateThongTinGiamTruCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewThongTinGiamTru), new { id = result}, new JsonResponse<ThongTinGiamTruDTO>(result));
        }
        [HttpPut]
        [Route("Thong-Tin-Giam-Tru")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinGiamTruDTO>> UpdateThongTinGiamTru(
            [FromBody] UpdateThongTinGiamTruCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruDTO>(result));

        }
        [HttpDelete]
        [Route("Thong-Tin-Giam-Tru")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> DeleteThongTinGiamTru(
            [FromBody] DeleteThongTinGiamTruCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
