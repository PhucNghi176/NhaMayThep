using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.KhenThuong.UpdateKhenThuong
{
    public class UpdateKhenThuongCommandHandler : IRequestHandler<UpdateKhenThuongCommand, string>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public UpdateKhenThuongCommandHandler(IKhenThuongRepository repository, IMapper mapper, INhanVienRepository nhanvien, NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }
        public UpdateKhenThuongCommandHandler() { }
        public async Task<string> Handle(UpdateKhenThuongCommand request, CancellationToken cancellationToken)
        {
            if(request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Không tìm thấy nhân viên với ID : {request.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            }
            if(request.ChinhSachNhanSuID != null)
            {
                var chinhsach = await this._chinhsach.FindAsync(x => x.ID.Equals(request.ChinhSachNhanSuID) && x.NgayXoa == null, cancellationToken);
                if (chinhsach == null)
                    throw new NotFoundException($"Không tìm thấy chính sách nhân sự với ID : {request.ChinhSachNhanSuID} hoặc chính sách nhân sự này đã bị xóa.");
            }
            var khenthuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (khenthuong == null)
                throw new NotFoundException($"Không tìm thấy khen thưởng với ID : {request.ID} hoặc khen thưởng này đã bị xóa.");
            khenthuong.TenDotKhenThuong = request.TenDotKhenThuong ?? khenthuong.TenDotKhenThuong;
            khenthuong.NguoiCapNhatID = this._currentUserService.UserId;
            khenthuong.TongThuong = request.TongThuong;
            khenthuong.NgayCapNhatCuoi = DateTime.UtcNow;
            khenthuong.MaSoNhanVien = request.MaSoNhanVien ?? khenthuong.MaSoNhanVien;
            khenthuong.ChinhSachNhanSuID = request.ChinhSachNhanSuID;
            this._repository.Update(khenthuong);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Cập nhật thành công hạng mục khen thưởng có ID : {request.ID}";
        }
    }
}
