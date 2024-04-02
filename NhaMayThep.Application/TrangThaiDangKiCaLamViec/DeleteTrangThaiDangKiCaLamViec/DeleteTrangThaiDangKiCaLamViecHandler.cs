using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec
{
    public class DeleteTrangThaiDangKiCaLamViecHandler : IRequestHandler<DeleteTrangThaiDangKiCaLamViecCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;

        public DeleteTrangThaiDangKiCaLamViecHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, 
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
        }

        public async Task<string> Handle(DeleteTrangThaiDangKiCaLamViecCommand request, CancellationToken cancellationToken)
        {
            var trangThai = await _trangThaiDangKiCaLamViecRepository.FindAsync(x => x.ID == request.Id, cancellationToken);


            if (trangThai is null || trangThai.NgayXoa.HasValue)
            {
                return "Xóa Thất Bại";
            }

            trangThai.NguoiXoaID = _currentUserService.UserId;
            trangThai.NgayXoa = DateTime.Now;
            _trangThaiDangKiCaLamViecRepository.Update(trangThai);
            return await _trangThaiDangKiCaLamViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Thành Công" : "Xóa Thất Bại" ;
        }
    }
}
