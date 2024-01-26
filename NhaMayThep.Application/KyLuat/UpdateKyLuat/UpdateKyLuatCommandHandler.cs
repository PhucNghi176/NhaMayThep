using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KyLuat.UpdateKyLuat
{
    public class UpdateKyLuatCommandHandler : IRequestHandler<UpdateKyLuatCommand, KyLuatDTO>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public UpdateKyLuatCommandHandler(IKyLuatRepository repository, IMapper mapper, INhanVienRepository nhanvien, IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }

        public UpdateKyLuatCommandHandler() { }
        public async Task<KyLuatDTO> Handle(UpdateKyLuatCommand request, CancellationToken cancellationToken)
        {
            if(request.MaNhanVien != null)
            {
                var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaNhanVien} không tồn tại hoặc đã xóa.");
            }
            var chinhsach = await this._chinhsach.FindAsync(x => x.ID.Equals(request.ChinhSachNhanSuID) && x.NgayXoa == null, cancellationToken);
            if (chinhsach == null)
                throw new NotFoundException($"Chính sách nhân sự với ID : {request.ChinhSachNhanSuID} không tồn tại hoặc đã xóa.");
            var kyluat = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null,cancellationToken);
            if (kyluat == null)
                throw new NotFoundException($"Không tìm thấy trường hợp kỷ luật với ID : {request.ID} hoặc trường hợp này đã bị xóa.");
            kyluat.NguoiCapNhatID = this._currentUserService.UserId;
            kyluat.NgayCapNhatCuoi = DateTime.UtcNow;
            kyluat.TongPhat = request.TongPhat;
            kyluat.ChinhSachNhanSuID = request.ChinhSachNhanSuID;
            kyluat.MaSoNhanVien = request.MaNhanVien ?? kyluat.MaSoNhanVien;
            this._repository.Update(kyluat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return kyluat.MapToKyLuatDTO(_mapper);
        }
    }
}
