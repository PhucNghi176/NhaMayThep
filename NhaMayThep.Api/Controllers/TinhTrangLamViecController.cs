using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinGiamTru;
using NhaMayThep.Application.TinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID;
using NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    public class TinhTrangLamViecController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TinhTrangLamViecController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        [HttpGet]
        [Route("TinhTrangLamViec")]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TinhTrangLamViecDTO>>> getAll(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllTinhTrangLamViecQuery(),cancellationToken);
            return Ok(new JsonResponse<List<TinhTrangLamViecDTO>>(result));
        }
        [HttpGet]
        [Route("TinhTrangLamViec/{Id}")]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TinhTrangLamViecDTO>> getById(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetTinhTrangLamViecByIDQuery(Id),cancellationToken);
            return Ok(new JsonResponse<TinhTrangLamViecDTO>(result));
        }
        [HttpPost]
        [Route("TinhTrangLamViec")]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TinhTrangLamViecDTO>> createNewTinhTrangLamViec(
            [FromBody] CreateTinhTrangLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new JsonResponse<TinhTrangLamViecDTO>(result));
        }
        [HttpPut]
        [Route("TinhTrangLamViec")]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TinhTrangLamViecDTO>> updateTinhTrangLamViec(
            [FromBody] UpdateTinhTrangLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(updateTinhTrangLamViec), new { id = result }, new JsonResponse<TinhTrangLamViecDTO>(result));
        }
        [HttpDelete]
        [Route("TinhTrangLamViec")]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> deleteTinhTrangLamViec(
            [FromBody] DeleteTinhTrangLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
    }
}
