using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Exceptions;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.Update
{
    public class UpdateBaoHiemNhanVienCommandHandler : IRequestHandler<UpdateBaoHiemNhanVienCommand, string>
    {
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        public UpdateBaoHiemNhanVienCommandHandler(IBaoHiemNhanVienRepository baoHiemNhanVienRepository, IMapper mapper, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository, IBaoHiemRepository baoHiemRepository)
        {
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
            _baoHiemRepository = baoHiemRepository;
        }

        public async Task<string> Handle(UpdateBaoHiemNhanVienCommand request, CancellationToken cancellationToken)
        {
            var baoHiemNhanVien = await _baoHiemNhanVienRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);
            if (baoHiemNhanVien == null)
            {
                throw new NotFoundException("Không tìm thấy hoặc bản ghi Bảo Hiểm Nhân Viên đã bị xóa trước đó!");
            }

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Mã Số Nhân Viên không tồn tại!");
            }

            var baoHiem = await _baoHiemRepository.FindAsync(x => x.ID == request.BaoHiem && x.NgayXoa == null, cancellationToken);
            if (baoHiem == null)
            {
                throw new NotFoundException("Bảo Hiểm không tồn tại!");
            }

            var existingBaoHiemNhanVien = await _baoHiemNhanVienRepository.AnyAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.BaoHiem == request.BaoHiem && x.ID != request.Id && x.NgayXoa == null, cancellationToken);

            if (existingBaoHiemNhanVien)
            {
                throw new NotFoundException("Bảo Hiểm đã tồn tại cho nhân viên này!");
            }

            baoHiemNhanVien.MaSoNhanVien = request.MaSoNhanVien;
            baoHiemNhanVien.BaoHiem = request.BaoHiem;
            baoHiemNhanVien.NguoiCapNhatID = _currentUserService.UserId;
            baoHiemNhanVien.NgayCapNhatCuoi = DateTime.Now;

            _baoHiemNhanVienRepository.Update(baoHiemNhanVien);
            await _baoHiemNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Cập nhật thành công!";
        }
    }
}
