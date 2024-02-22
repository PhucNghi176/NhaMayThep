using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Application.NhanVien.Authenticate.Login;
using NhaMayThep.Application.NhanVien.ChangePasswordNhanVIen;
using NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand;
using NhaMayThep.Application.NhanVien.DeleteNhanVien;
using NhaMayThep.Application.NhanVien.FilterByChucDanhChucVuTinhTrangLamViec;
using NhaMayThep.Application.NhanVien.GetAllNhanVien;
using NhaMayThep.Application.NhanVien.GetAllNhanVienWithoutHopDong;
using NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail;
using NhaMayThep.Application.NhanVien.GetNhanVien;
using NhaMayThep.Application.NhanVien.GetNhanVienIDByEmail;
using NhaMayThep.Application.NhanVien.GetNhanVienTest;
using NhaMayThep.Application.NhanVien.UpdateNhanVien;
using NhaMayThep.Application.ThongTinChucVu;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    [Authorize]
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
        [Route("nhan-vien")]
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
        [Route("nhan-vien/login")]
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
        [Route("nhan-vien/doi-mat-khau")]
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
        [Route("nhan-vien")]
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
        [HttpGet]
        [Route("nhan-vien/get-nhanvienID")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> GetUserID(
                                  [FromQuery] GetNhanVienIDByEmailQuery query,
                                                                   CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("nhan-vien/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<NhanVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<NhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<NhanVienDto>>>> GetAll(
            [FromQuery] GetAllNhanVienQuery query,
             CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        [Route("nhan-vien/get-all-without-hopdong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<JsonResponse<NhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<NhanVienDto>>>> GetAllNhanVienWithoutHopDong([FromQuery] GetAllNhanVienWithoutHopDongQuery query,
                        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        [HttpDelete("nhan-vien/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteNhanVien([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteNhanVienCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut("nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Update([FromBody] UpdateNhanVienCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet("nhan-vien/get-all-test")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<NhanVienDto>>> Test(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetNhanVienTestQuery(), cancellationToken); return Ok(result);
        }
        [HttpGet("nhan-vien/{HoTenHoacEmail}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<NhanVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<NhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<NhanVienDto>>>> getHoVaTenNhanVienByEmail([FromRoute] string HoTenHoacEmail, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new FilterByHotenNhanVienOrEmailNhanVienQuery(HoTenHoacEmail: HoTenHoacEmail), cancellationToken);
            return Ok(new JsonResponse<List<NhanVienDto>>(result));
        }
        
        [HttpGet]
        [Route("nhan-vien/{no}/{pageSize}/{tenChucVuHoacTinhTrangLamViec}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<NhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<NhanVienDto>>>> getByChucVuTinhTrangLamViec(
            [FromRoute] int no,
            [FromRoute] int pageSize,
            [FromRoute] string tenChucVuHoacTinhTrangLamViec,
             CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new FilterByChucDanhChucVuTinhTrangLamViecQuery(pageNumber : no, pageSize: pageSize, ChucVuHoacTinhTrangLamViec : tenChucVuHoacTinhTrangLamViec), cancellationToken);
            return Ok(result);
        }
    }
}
