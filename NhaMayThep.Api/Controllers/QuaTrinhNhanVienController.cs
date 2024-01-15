using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.QuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class QuaTrinhNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;
        public QuaTrinhNhanVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("Create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QuaTrinhNhanSuDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuaTrinhNhanSuDto>> Create(
            [FromBody] CreateQuaTrinhNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);            
            return Ok(result);
        }
    }
}
