using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinCongTy;
using NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy;
using NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy;
using NhaMayThep.Application.ThongTinCongTy.GetAllThongTinCongTy;
using NhaMayThep.Application.ThongTinCongTy.GetThongTinCongTyById;
using NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy;

namespace NhaMayThep.Api.Controllers.ThongTinCongTy
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinCongTyController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinCongTyController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewThongTinCongTy(
            [FromBody] CreateThongTinCongTyCommand command, CancellationToken cancellationToken = default
        )
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinCongTyDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongTyDto>>> GetAllThongTinCongTy(
    
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinCongTyQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinCongTyDto>>(result));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongTyDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongTyDto>>> GetThongTinCongTyById(
                       [FromRoute] int id,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongTyByIdQuery(id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongTyDto>(result));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteThongTinCongTy(
                       [FromRoute] int id,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinCongTyCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateThongTinCongTy(
                       [FromBody] UpdateThongTinCongTyCommand command,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}