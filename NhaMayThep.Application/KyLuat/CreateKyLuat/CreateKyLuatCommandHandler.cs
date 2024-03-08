using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.CreateKyLuat
{
    public class CreateKyLuatCommandHandler : IRequestHandler<CreateKyLuatCommand, string>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public CreateKyLuatCommandHandler(IKyLuatRepository repository, IMapper mapper, INhanVienRepository nhanvien, NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }

        public CreateKyLuatCommandHandler() { }
        public async Task<string> Handle(CreateKyLuatCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaSoNhanVien)&& x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            var chinhsach = await this._chinhsach.FindAsync(x => x.ID.Equals(request.ChinhSachNhanSuID) && x.NgayXoa == null, cancellationToken );
            if (chinhsach == null)
                throw new NotFoundException($"Chính sách nhân sự với ID : {request.ChinhSachNhanSuID} không tồn tại hoặc đã xóa.");
            var kyluat = new KyLuatEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                ChinhSachNhanSuID = request.ChinhSachNhanSuID,
                TenDotKyLuat = request.TenDotKyLuat,
                NgayKiLuat = DateTime.UtcNow,
                TongPhat = request.TongPhat,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = this._currentUserService.UserId,
            };
            this._repository.Add(kyluat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Tạo thành công trường hợp kỷ luật cho nhân viên có ID : {request.MaSoNhanVien}";
        }
    }
}
