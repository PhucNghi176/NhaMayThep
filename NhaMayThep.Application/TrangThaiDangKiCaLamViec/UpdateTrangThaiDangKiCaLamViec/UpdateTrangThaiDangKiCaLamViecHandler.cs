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

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec
{
    public class UpdateTrangThaiDangKiCaLamViecHandler : IRequestHandler<UpdateTrangThaiDangKiCaLamViecCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;
        public readonly IMapper _mapper;

        public UpdateTrangThaiDangKiCaLamViecHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateTrangThaiDangKiCaLamViecCommand request, CancellationToken cancellationToken)
        {
            var trangThai = await _trangThaiDangKiCaLamViecRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (trangThai == null || trangThai.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Trạng Thái Trên Không Tồn Tại");
            }
            trangThai.Name = request.Name;
            trangThai.NguoiCapNhatID = _currentUserService.UserId;
            trangThai.NgayCapNhat = DateTime.Now;
            _trangThaiDangKiCaLamViecRepository.Update(trangThai);
            return await _trangThaiDangKiCaLamViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập Nhật Thành Công" : "Cập Nhật Thất Bại";
        }
    }
}
