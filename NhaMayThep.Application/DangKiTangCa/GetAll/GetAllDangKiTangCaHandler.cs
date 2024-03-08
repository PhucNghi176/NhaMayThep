using MediatR;
using NhaMayThep.Application.LichSuNghiPhep.GetAll;
using NhaMayThep.Application.LichSuNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.DangKiTangCa.GetAll
{
    public class GetAllDangKiTangCaHandler : IRequestHandler<GetAllDangKyTangCaQuery, List<DangKiTangCaDto>>
    {
        private readonly IDangKiTangCaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDangKiTangCaHandler(IDangKiTangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DangKiTangCaDto>> Handle(GetAllDangKyTangCaQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lsnp.MapToDangKiTangCaDtoList(_mapper);
        }
    }
}
