using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.GetHangLoat;
using NhaMayThep.Application.GetHangLoat.GetHangLoatHopDong;
using NhaMayThep.Application.GetHangLoat.GetHangLoatNhanVien;
using NhaMayThep.Application.GetHangLoat.GetHangLoatQuaTrinhNhanSu;

namespace NhaMayThep.Api.Controllers.GetHangLoat
{
    [ApiController]

    public class GetHangLoatController : ControllerBase
    {
        private readonly ISender _mediator;

        public GetHangLoatController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        [Route("hang-loat/nhan-vien")]
        public async Task<IActionResult> GetHangLoat(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHangLoatNhanVienQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("hang-loat/hop-dong")]
        public async Task<IActionResult> GetHangLoatHopDong(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHangLoatHopDongQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("hang-loat/qua-trinh-nhan-su")]
        public async Task<IActionResult> GetHangLoatQuaTrinhNhanSu(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHangLoatQuaTrinhNhanSuQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
