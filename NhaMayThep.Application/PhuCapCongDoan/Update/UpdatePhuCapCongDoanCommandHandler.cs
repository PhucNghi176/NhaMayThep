using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.Update
{
    public class UpdatePhuCapCongDoanCommandHandler : IRequestHandler<UpdatePhuCapCongDoanCommand, string>
    {
        ICurrentUserService _currentUserService;
        IPhuCapCongDoanRepository _PhuCapCongDoanRepository;
        public UpdatePhuCapCongDoanCommandHandler(ICurrentUserService currentUserService, IPhuCapCongDoanRepository PhuCapCongDoanRepository)
        {
            _currentUserService = currentUserService;
            _PhuCapCongDoanRepository = PhuCapCongDoanRepository;
        }

        public async Task<string> Handle(UpdatePhuCapCongDoanCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _PhuCapCongDoanRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.HeSoPhuCap = command.HeSoPhuCap;
            existEntity.SoLuongDoanVien = command.SoLuongDoanVien;
            existEntity.DonVi = command.DonVi;
            existEntity.NgayCapNhatCuoi = DateTime.UtcNow;
            existEntity.NguoiCapNhatID = _currentUserService.UserId;
            _PhuCapCongDoanRepository.Update(existEntity);
            return await _PhuCapCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Phụ Cấp Công Đoàn thành công" : "Cập nhật Phụ Cấp Công Đoàn thất bại";
        }
    }
}
