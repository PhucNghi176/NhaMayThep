using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommandHandler : IRequestHandler<CreateKhaiBaoTangLuongCommand, string>
    {
        private IKhaiBaoTangLuongRepository _KhaiBaoTangLuongRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository KhaiBaoTangLuongRepository, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _KhaiBaoTangLuongRepository = KhaiBaoTangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Không tìm thấy nhân viên với ID : {request.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            var KhaiBaoTangLuong = new KhaiBaoTangLuongEntity()
            {

                MaSoNhanVien = nhanVien.ID,
                NhanVien = nhanVien,
                PhanTramTang = request.PhanTramTang,
                NgayApDung = request.NgayApDung,
                LyDo = request.LyDo,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _KhaiBaoTangLuongRepository.Add(KhaiBaoTangLuong);
            await _KhaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo Khai Báo Tăng Lương thành công";
        }
    }
}