using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Create
{
    public class CreateLuongCongNhatCommandHandler : IRequestHandler<CreateLuongCongNhatCommand, string>
    {
        private ILuongCongNhatRepository _LuongCongNhatRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateLuongCongNhatCommandHandler(ILuongCongNhatRepository LuongCongNhatRepository, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateLuongCongNhatCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _LuongCongNhatRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai Luong Cong Nhat");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            var LuongCongNhat = new LuongCongNhatEntity()
            {
                ID = request.ID,
                MaSoNhanVien = nhanVien.ID,
                NhanVien = nhanVien,
                Luong1Gio = request.Luong1Gio,
                TongLuong = request.TongLuong,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _LuongCongNhatRepository.Add(LuongCongNhat);
            await _LuongCongNhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return LuongCongNhat.ID;
        }
    }
}