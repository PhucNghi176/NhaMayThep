using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

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
            var existingBaoHiemNhanVien = await _baoHiemNhanVienRepository.AnyAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.ID != request.Id && x.NgayXoa == null, cancellationToken);

            if (existingBaoHiemNhanVien)
            {
                throw new NotFoundException("Bảo Hiểm đã tồn tại cho nhân viên này!");
            }

            baoHiemNhanVien.MaSoNhanVien = request.MaSoNhanVien;
            baoHiemNhanVien.NguoiCapNhatID = _currentUserService.UserId;
            baoHiemNhanVien.NgayCapNhat = DateTime.Now;

            _baoHiemNhanVienRepository.Update(baoHiemNhanVien);
            if (await _baoHiemNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công!";
            else
                return "Cập nhật thất bại!";
        }
    }
}
