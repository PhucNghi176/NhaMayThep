using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.CanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan;
using NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanById;
using NhaMayThep.Application.CanCuocCongDan.UpdateCanCuocCongDan;
using NhaMayThep.Application.Common.Interfaces;
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
        [Route("api/CanCuocCongDan/")]
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
        [Route("api/CanCuocCongDan/")]
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
        [Route("api/CanCuocCongDan/")]
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
        [Route("api/CanCuocCongDan/")]
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
    }
}
