using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVien
{
    public class GetAllNhanVienQueryHandler : IRequestHandler<GetAllNhanVienQuery, List<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        public GetAllNhanVienQueryHandler(INhanVienRepository nhanvienReopsitory, IMapper mapper, IChucVuRepository chucvuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository)
        {
            _nhanvienRepository = nhanvienReopsitory;
            _mapper = mapper;
            _chucVuRepository = chucvuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
        }

        public async Task<List<NhanVienDto>> Handle(GetAllNhanVienQuery request, CancellationToken cancellationToken)
        {

            var list = await _nhanvienRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
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
