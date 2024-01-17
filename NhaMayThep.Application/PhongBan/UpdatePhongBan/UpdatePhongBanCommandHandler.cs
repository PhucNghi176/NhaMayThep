using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandHandler : IRequestHandler<UpdatePhongBanCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePhongBanCommandHandler(IMapper mapper, IPhongBanRepository phongBanRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _phongBanRepository = phongBanRepository;
        }

        public async Task<bool> Handle(UpdatePhongBanCommand command, CancellationToken cancellationToken)
        {
            var entity = _phongBanRepository.FindAsync(x => x.ID == command.ID).Result;
            entity.Name = command.Name;
            entity.NguoiCapNhatID = _currentUserService.UserId;
            entity.NgayCapNhat = DateTime.UtcNow;
            _phongBanRepository.Update(entity);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
