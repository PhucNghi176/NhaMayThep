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
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.KhenThuong.CreateKhenThuong
{
    public class CreateKhenThuongCommandHandler : IRequestHandler<CreateKhenThuongCommand, string>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public CreateKhenThuongCommandHandler(IKhenThuongRepository repository, IMapper mapper, INhanVienRepository nhanvien, IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }
        public CreateKhenThuongCommandHandler() { }
        public async Task<string> Handle(CreateKhenThuongCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null) 
                throw new NotFoundException($"Không tìm thấy nhân viên với ID : {request.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            var chinhsach = await this._chinhsach.FindAsync(x => x.ID.Equals(request.ChinhSachNhanSuID) && x.NgayXoa == null, cancellationToken);
            if (chinhsach == null)
                throw new NotFoundException($"Không tìm thấy chính sách nhân sự với ID : {request.ChinhSachNhanSuID} hoặc chính sách nhân sự này đã bị xóa.");
            var khenthuong = new KhenThuongEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                ChinhSachNhanSuID = request.ChinhSachNhanSuID,
                NgayKhenThuong = DateTime.UtcNow,
                TongThuong = request.TongThuong,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = this._currentUserService.UserId,
            };
            this._repository.Add(khenthuong);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Tạo thành công hạng mục khen thưởng cho nhân viên có ID : {request.MaSoNhanVien}";
        }
    }
}
