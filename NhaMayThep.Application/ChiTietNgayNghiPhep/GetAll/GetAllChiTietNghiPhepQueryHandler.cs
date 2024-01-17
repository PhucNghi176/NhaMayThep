using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll
{
    public class GetAllChiTietNghiPhepQueryHandler : IRequestHandler<GetAllChiTietNghiPhepQuery, List<ChiTietNgayNghiPhepDto>>
    {
        private readonly IChiTietNgayNghiPhepRepository _repo;
        private readonly IMapper _mapper;

        public GetAllChiTietNghiPhepQueryHandler(IChiTietNgayNghiPhepRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ChiTietNgayNghiPhepDto>> Handle(GetAllChiTietNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var ctnp = await _repo.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return ctnp.MapToChiTietNgayNghiPhepDtoList(_mapper);
        }
    }
}
