using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.Logs.DowloadFileLogs;
using NhaMayThep.Application.HoaDonCongTacNhanVien.DowloadFile;
using System.Net.Mime;
using NhaMayThep.Application.Logs.GetNewestLogs;
using NhaMapThep.Api.Controllers.ResponseTypes;

namespace NhaMayThep.Api.Controllers
{
    
    [ApiController]
    //[Authorize]
    public class LogsController : ControllerBase
    {
        private readonly ISender _mediator;

        public LogsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("logs/dowloadFile")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DowloadFile(CancellationToken cancellationToken = default)
        {
           
            var result = await _mediator.Send(new DowloadFileLogsQuery(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return result;
        }

        [HttpGet("logs/GetFile")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetFile(int lineCount,CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new GetNewestLogsQuery(lineCount), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<string>>(result));
        }
    }
}
