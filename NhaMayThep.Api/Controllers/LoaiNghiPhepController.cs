﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using NhaMayThep.Application.LoaiNghiPhep.Create;
using NhaMayThep.Application.LoaiNghiPhep.Delete;
using NhaMayThep.Application.LoaiNghiPhep.GetAll;
using NhaMayThep.Application.LoaiNghiPhep.GetById;
using NhaMayThep.Application.LoaiNghiPhep.Update;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using NhaMayThep.Application.LoaiNghiPhep;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiNghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoaiNghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(CreateLoaiNghiPhepCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Loai Nghi Phep created successfully"));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteLoaiNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Loai Nghi Phep deleted successfully"));
        }



        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdateLoaiNghiPhepCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Loai Nghi Phep updated successfully"));
        }

        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiNghiPhepDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<LoaiNghiPhepDto>>(result));
        }

        [HttpGet("getById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiNghiPhepDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLoaiNghiPhepByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<LoaiNghiPhepDto>(result));
        }
    }
}