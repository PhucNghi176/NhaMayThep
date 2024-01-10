using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Application.Authenticate.Login;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMapThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IJwtService _jwtService;

        public AuthenticationController(ISender mediator, IJwtService jwtGenerator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _jwtService = jwtGenerator ?? throw new ArgumentNullException(nameof(jwtGenerator));
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login(
                       [FromBody] GetUserQuery command,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
            {
                return Unauthorized();
            }
            var token = _jwtService.CreateToken(result.userName);
            return Ok(new { token });
        }
    }
}
