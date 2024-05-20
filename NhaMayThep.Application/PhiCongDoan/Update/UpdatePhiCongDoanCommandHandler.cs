using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhiCongDoan.Update
{
    public class UpdatePhiCongDoanCommandHandler : IRequestHandler<UpdatePhiCongDoanCommand, string>
    {
        private IPhiCongDoanRepository _PhiCongDoanRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePhiCongDoanCommandHandler(IPhiCongDoanRepository PhiCongDoanRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _PhiCongDoanRepository = PhiCongDoanRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdatePhiCongDoanCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            }

            var PhiCongDoan = await _PhiCongDoanRepository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (PhiCongDoan == null)
                throw new NotFoundException($"Không tìm thấy Phí Công Đoàn với ID : {request.Id} hoặc trường hợp này đã bị xóa.");

            var checkDuplication = await _PhiCongDoanRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.ID != request.Id && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplication != null)
                throw new NotFoundException("Nhan Vien co ID: " + request.MaSoNhanVien + "da ton tai Phi Cong Doan");


            PhiCongDoan.LuongDongBH = request.LuongDongBH;
            PhiCongDoan.PhanTramLuongDongBH = request.PhanTramLuongDongBH;
            PhiCongDoan.NguoiCapNhatID = _currentUserService.UserId;
            PhiCongDoan.NgayCapNhatCuoi = DateTime.Now;

            _PhiCongDoanRepository.Update(PhiCongDoan);
            return await _PhiCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Phí Công Đoàn thành công" : "Cập nhật Phí Công Đoàn thất bại";
        }
    }
}
