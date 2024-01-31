using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Security;
using NhaMayThep.Application.ThongTinGiamTru;
using NhaMayThep.Application.TinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec;
using NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID;
using NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class TinhTrangLamViecController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TinhTrangLamViecController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        [HttpGet]
        [Route("TinhTrangLamViec")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<TinhTrangLamViecDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<TinhTrangLamViecDTO>>), StatusCodes.Status200OK)]
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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<TinhTrangLamViecDTO>), StatusCodes.Status200OK)]
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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> createNewTinhTrangLamViec(
            [FromBody] CreateTinhTrangLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [Route("TinhTrangLamViec")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> updateTinhTrangLamViec(
            [FromBody] UpdateTinhTrangLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(updateTinhTrangLamViec), new { id = result }, new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("TinhTrangLamViec/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> deleteTinhTrangLamViec(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteTinhTrangLamViecCommand(Id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
