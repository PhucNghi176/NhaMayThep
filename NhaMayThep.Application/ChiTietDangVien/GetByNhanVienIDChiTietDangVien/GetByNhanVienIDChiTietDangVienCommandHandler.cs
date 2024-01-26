using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.GetByNhanVienIDChiTietDangVien
{
    public class GetByNhanVienIDChiTietDangVienCommandHandler : IRequestHandler<GetByNhanVienIDChiTietDangVienCommand, ChiTietDangVienDto>
    {
        private readonly IChiTietDangVienRepository _chiTietDangVienRepository;
        private readonly IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;

        public GetByNhanVienIDChiTietDangVienCommandHandler(IChiTietDangVienRepository chiTietDangVienRepository, IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }

        public async Task<ChiTietDangVienDto> Handle(GetByNhanVienIDChiTietDangVienCommand request, CancellationToken cancellationToken)
        {
            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken);
            if (thongTinDangVien == null)
                throw new NotFoundException("Nhân Viên chưa có Thông Tin Đảng Viên");
            
            var chiTietDangVien = await _chiTietDangVienRepository.FindAsync(x => x.DangVienID == thongTinDangVien.ID && x.NgayXoa == null, cancellationToken);
            if(chiTietDangVien == null)
                throw new NotFoundException("Không tìm thấy Chi Tiết Đảng Viên");

            return chiTietDangVien.MapToChiTietDangVienDto(_mapper);
        }
    }
}
