using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandHandler : IRequestHandler<CreatePhongBanCommand, PhongBanDto>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        public CreatePhongBanCommandHandler(IPhongBanRepository phongBanRepository, IMapper mapper)
        {
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task<PhongBanDto> Handle(CreatePhongBanCommand command, CancellationToken cancellationToken)
        {
            PhongBanEntity entity = new PhongBanEntity()
            {
                ID = command.ID,
                Name = command.Name,
            };
            _phongBanRepository.Add(entity);
            await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity.MapToPhongBanDto(_mapper);
        }
    }
}
