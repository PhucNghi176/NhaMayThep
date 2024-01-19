using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LoaiNghiPhepDto>>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILoaiNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LoaiNghiPhepDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lnp.MapToLoaiNghiPhepDtoList(_mapper);
        }
    }
}