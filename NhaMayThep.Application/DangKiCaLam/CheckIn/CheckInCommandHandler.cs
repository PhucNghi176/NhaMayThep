using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.CheckIn
{
    public class CheckInCommandHandler : IRequestHandler<CheckInCommand, string>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CheckInCommandHandler(IDangKiCaLamRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CheckInCommand request, CancellationToken cancellationToken)
        {

            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null || dangKiCaLam.NgayXoa.HasValue)
            {
                throw new NotFoundException($"Không tìm thấy đăng kí ca làm với Id {request.Id}.");
            }

            var now = DateTime.UtcNow;
            dangKiCaLam.ThoiGianChamCongBatDau = now;

            if (now > dangKiCaLam.ThoiGianCaLamBatDau)
            {
                // Late check-in
                dangKiCaLam.GhiChu += " Check-in trễ.";
            }



            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Check-in thành công" : "Check-in thất bại";
        }
    }

}

