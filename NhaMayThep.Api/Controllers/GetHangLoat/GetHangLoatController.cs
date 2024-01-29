using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.GetHangLoat;

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
        [Route("get-hang-loat/nhan-vien")]
        public async Task<IActionResult> GetHangLoat(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetHangLoatQuery(), cancellationToken);
            return Ok(result);
        }

    }
}
