using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LoaiTangCaDto>>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILoaiTangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LoaiTangCaDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lnp.MapToLoaiTangCaDtoList(_mapper);
        }
    }
}
