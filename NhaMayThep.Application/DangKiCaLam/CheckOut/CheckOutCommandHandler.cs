using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.CheckOut
{
    public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand, string>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CheckOutCommandHandler(IDangKiCaLamRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CheckOutCommand request, CancellationToken cancellationToken)
        {
            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null || dangKiCaLam.NgayXoa.HasValue)
            {
                throw new NotFoundException($"Không tìm thấy Đăng Kí Ca LÀm  {request.Id}.");
            }

            var now = DateTime.UtcNow; // Consider using a specific timezone if needed
            var scheduledEndTimePassed = now > dangKiCaLam.ThoiGianCaLamKetThuc.AddHours(2); // Example threshold of 2 hours after scheduled end time

            if (scheduledEndTimePassed)
            {
                // Missed check-out scenario
                dangKiCaLam.GhiChu += " Không Check Out.";
            }
            else if (now < dangKiCaLam.ThoiGianCaLamKetThuc)
            {
                // Early check-out
                dangKiCaLam.GhiChu += " Check-out sớm.";
                dangKiCaLam.ThoiGianChamCongKetThuc = now;
            }
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Check-out thành công" : "Check-out thất bại";



        }
    }
}
