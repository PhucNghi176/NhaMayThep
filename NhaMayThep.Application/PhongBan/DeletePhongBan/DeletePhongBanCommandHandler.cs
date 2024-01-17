using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandHandler : IRequestHandler<DeletePhongBanCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePhongBanCommandHandler(IPhongBanRepository phongBanRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeletePhongBanCommand command, CancellationToken cancellationToken)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == command.ID).Result;
            phongBan.NgayXoa = DateTime.UtcNow;
            phongBan.NguoiXoaID = _currentUserService.UserId;
            _phongBanRepository.Update(phongBan);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
