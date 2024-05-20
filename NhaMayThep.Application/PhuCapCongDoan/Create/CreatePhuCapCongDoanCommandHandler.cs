using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.Create
{
    public class CreatePhuCapCongDoanCommandHandler : IRequestHandler<CreatePhuCapCongDoanCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IPhuCapCongDoanRepository _PhuCapCongDoanRepository;
        public CreatePhuCapCongDoanCommandHandler(ICurrentUserService currentUserService, IPhuCapCongDoanRepository PhuCapCongDoanRepository)
        {
            _currentUserService = currentUserService;
            _PhuCapCongDoanRepository = PhuCapCongDoanRepository;
        }
        public async Task<string> Handle(CreatePhuCapCongDoanCommand command, CancellationToken cancellationToken)
        {
            PhuCapCongDoanEntity entity = new PhuCapCongDoanEntity()
            {
                SoLuongDoanVien = command.SoLuongDoanVien,
                HeSoPhuCap = command.HeSoPhuCap,
                DonVi = command.DonVi,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = _currentUserService.UserId,
            };
            _PhuCapCongDoanRepository.Add(entity);
            return await _PhuCapCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Phụ Cấp Công Đoàn thành công" : "Tạo Phụ Cấp Công Đoàn thất bại";
        }
    }
}
