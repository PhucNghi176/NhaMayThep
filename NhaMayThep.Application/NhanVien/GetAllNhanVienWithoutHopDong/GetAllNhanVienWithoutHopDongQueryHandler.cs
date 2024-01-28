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
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;

        public GetAllNhanVienWithoutHopDongQueryHandler(INhanVienRepository nhanVienRepository, IMapper mapper, IChucVuRepository chucVuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
        }

        public async Task<List<NhanVienDto>> Handle(GetAllNhanVienWithoutHopDongQuery request, CancellationToken cancellationToken)
        {
            var list = await _nhanVienRepository.FindAllAsync(_ => _.NgayXoa == null && !_.DaCoHopDong, cancellationToken);
            var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var tinhtranglamviec = await _tinhTrangLamViecRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var returnList = new List<NhanVienDto>();
            foreach (var item in list)
            {
                var nvDto = _mapper.Map<NhanVienDto>(item);
                nvDto.ChucVu = chucvu.ContainsKey(item.ChucVuID) ? chucvu[item.ChucVuID] : "Lỗi";
                nvDto.TinhTrangLamViec = tinhtranglamviec.ContainsKey(item.TinhTrangLamViecID) ? tinhtranglamviec[item.TinhTrangLamViecID] : "Lỗi";
                returnList.Add(nvDto);
            }
            return returnList;
        }
    }
}
