using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVienWithoutHopDong
{
    public class GetAllNhanVienWithoutHopDongQueryHandler : IRequestHandler<GetAllNhanVienWithoutHopDongQuery, List<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IHopDongRepository _hopDongRepository;

        public GetAllNhanVienWithoutHopDongQueryHandler(INhanVienRepository nhanVienRepository, IMapper mapper, IChucVuRepository chucVuRepository, IHopDongRepository hopDongRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
            _hopDongRepository = hopDongRepository;
        }

        public async Task<List<NhanVienDto>> Handle(GetAllNhanVienWithoutHopDongQuery request, CancellationToken cancellationToken)
        {
            var list = await _nhanVienRepository.FindAllAsync(x => x.NgayXoa == null && x.DaCoHopDong == false, cancellationToken);
            var returnList = new List<NhanVienDto>();
            foreach (var item in list)
            {
                var chucVu = await _chucVuRepository.FindAsync(x => x.ID == item.ChucVuID && x.NgayXoa == null, cancellationToken);
                var nvDto = _mapper.Map<NhanVienDto>(item);
                nvDto.ChucVu = chucVu.Name;
                returnList.Add(nvDto);
            }
            return returnList;
        }
    }
}
