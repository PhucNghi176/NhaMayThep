using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Application.NhanVien.ChangePasswordNhanVIen;
using NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand;
using NhaMayThep.Application.NhanVien.GetNhanVien;
using NhaMayThep.Application.NhanVien.GetUser;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;
        public NhanVienController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }
        [HttpPost]
        [Route("api/nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewNhanVien(
            [FromBody] CreateNewNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/nhan-vien/login")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Login(
                       [FromBody] LoginQuery query,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            var token = _jwtService.CreateToken(result.Email, result.ID, result.ChucVu);
            return Ok(new JsonResponse<string>(token));
        }

        [HttpPost]
        [Route("api/nhan-vien/doi-mat-khau")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ChangePassword(
                                  [FromBody] ChangePasswordNhanVienCommand command,
                                                                   CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("api/nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<NhanVienDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<NhanVienDto>>> GetNhanVien(
                       [FromQuery] GetNhanVienQuery query,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<NhanVienDto>(result));
        }

    }
}
