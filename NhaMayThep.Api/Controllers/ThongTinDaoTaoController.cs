using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.ThongTinDaoTao.Create;
using NhaMayThep.Application.ThongTinDaoTao.Delete;
using NhaMayThep.Application.ThongTinDaoTao.GetAll;
using NhaMayThep.Application.ThongTinDaoTao.GetById;
using NhaMayThep.Application.ThongTinDaoTao.Update;
using NhaMayThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinDaoTaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;

        public ThongTinDaoTaoController(IMediator mediator, IThongTinDaoTaoRepository thongTinDaoTaoRepository)
        {
            _mediator = mediator;
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateThongTinDaoTao([FromBody] CreateThongTinDaoTaoCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetThongTinDaoTaoById), new { id = result }, null);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteThongTinDaoTao(string id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteThongTinDaoTaoCommand(id);
            var result = await _mediator.Send(command, cancellationToken);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateThongTinDaoTao(string id, [FromBody] UpdateThongTinDaoTaoCommand command, CancellationToken cancellationToken = default)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetThongTinDaoTaoById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllThongTinDaoTao(CancellationToken cancellationToken = default)
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
