using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.CreateLuongThoiGian
{
    public class CreateLuongThoiGianCommandHandler : IRequestHandler<CreateLuongThoiGianCommand, string>
    {
        private readonly ILuongThoiGianRepository _luongThoiGianRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateLuongThoiGianCommandHandler(ILuongThoiGianRepository luongThoiGianRepository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _luongThoiGianRepository = luongThoiGianRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<string> Handle(CreateLuongThoiGianCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!nhanVien)
                throw new NotFoundException("Nhân viên này không tồn tại");

            var checkDuplicatoion = await _luongThoiGianRepository.AnyAsync(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Lương thời gian của nhân viên này đã tồn tại");

            var luongThoiGian = new LuongThoiGianEntity()
            {
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
                MaSoNhanVien = request.MaSoNhanVien,
                MaLuongThoiGian = request.MaLuongThoiGian,
                LuongNam = request.LuongNam,
                LuongThang = request.LuongThang,
                LuongNgay = request.LuongNgay,
                LuongTuan = request.LuongTuan,
                LuongGio = request.LuongGio,
                NgayApDung = request.NgayApDung
            };

            _luongThoiGianRepository.Add(luongThoiGian);
            if (await _luongThoiGianRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
