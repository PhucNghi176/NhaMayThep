using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Admin.AdminAccount.Create;

namespace NhaMayThep.Api.Controllers.Admin
{

    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly ISender _meditar;

        public AdminController(ISender meditar)
        {
            _meditar = meditar;
        }
        [HttpPost]
        [Route("admin")]
        public async Task<ActionResult> CreateAdminAccount([FromBody] CreateAdminAccountCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _meditar.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
