using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien
{
    public class UpdateChiTietDangVienCommandHandler : IRequestHandler<UpdateChiTietDangVienCommand, ChiTietDangVienDto>
    {
        private IChiTietDangVienRepository _chiTietDangVienRepository;
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateChiTietDangVienCommandHandler(IChiTietDangVienRepository chiTietDangVienRepository, IThongTinDangVienRepository thongTinDangVienRepository, IDonViCongTacRepository donViCongTacRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<ChiTietDangVienDto> Handle(UpdateChiTietDangVienCommand request, CancellationToken cancellationToken)
        {
            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID ==  request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (thongTinDangVien == null)
                throw new NotFoundException("Nhân Viên chưa có Thông Tin Đảng Viên");

            var chiTietDangVien = await _chiTietDangVienRepository.FindAsync( x => x.DangVienID == thongTinDangVien.ID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if(chiTietDangVien == null)
                throw new NotFoundException("Không tìm thấy Chi Tiết Đàng Viên");

            var dangVien = await _thongTinDangVienRepository.AnyAsync(x => x.ID == request.DangVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!dangVien)
                throw new NotFoundException("Không tìm thấy Đảng Viên");

            var donViCongTac = await _donViCongTacRepository.AnyAsync(x => x.ID == request.DonViCongTacID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!donViCongTac)
                throw new NotFoundException("Không tìm thấy Đơn Vị Công Tác");

            chiTietDangVien.DangVienID = request.DangVienID; 
            chiTietDangVien.DonViCongTacID = request.DonViCongTacID;
            chiTietDangVien.ChucVuDang = request.ChucVuDang ;
            chiTietDangVien.TrinhDoChinhTri = request.TrinhDoChinhTri;

            chiTietDangVien.NguoiCapNhatID = _currentUserService.UserId;
            chiTietDangVien.NgayCapNhatCuoi = DateTime.Now;

            _chiTietDangVienRepository.Update(chiTietDangVien);
            await _chiTietDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return chiTietDangVien.MapToChiTietDangVienDto(_mapper);
        }
    }
}
