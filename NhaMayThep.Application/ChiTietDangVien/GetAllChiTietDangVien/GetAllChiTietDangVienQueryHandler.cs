using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien
{
    public class GetAllChiTietDangVienQueryHandler : IRequestHandler<GetAllChiTietDangVienQuery, List<ChiTietDangVienDto>>
    {
        private readonly IChiTietDangVienRepository _chiTietDangVienRepository;
        private readonly IMapper _mapper;

        public GetAllChiTietDangVienQueryHandler(IChiTietDangVienRepository chiTietDangVienRepository, IMapper mapper)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _mapper = mapper;
        }

        public async Task<List<ChiTietDangVienDto>> Handle(GetAllChiTietDangVienQuery request, CancellationToken cancellationToken)
        {

            var chiTietDangVienList = await _chiTietDangVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            return chiTietDangVienList.MapToChiTietDangVienDtoList(_mapper);
        }
    }
}
