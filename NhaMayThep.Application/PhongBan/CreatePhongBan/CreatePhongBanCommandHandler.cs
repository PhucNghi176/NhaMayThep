using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandHandler : IRequestHandler<CreatePhongBanCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePhongBanCommandHandler(IPhongBanRepository phongBanRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreatePhongBanCommand command, CancellationToken cancellationToken)
        {
            PhongBanEntity entity = new PhongBanEntity()
            {
                ID = command.ID,
                Name = command.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow              
            };
            _phongBanRepository.Add(entity);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
