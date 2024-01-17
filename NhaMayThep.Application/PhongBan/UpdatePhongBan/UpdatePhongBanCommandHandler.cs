using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandHandler : IRequestHandler<UpdatePhongBanCommand, PhongBanDto>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        public UpdatePhongBanCommandHandler(IMapper mapper, IPhongBanRepository phongBanRepository)
        {
            _mapper = mapper;
            _phongBanRepository = phongBanRepository;
        }

        public async Task<PhongBanDto> Handle(UpdatePhongBanCommand command, CancellationToken cancellationToken)
        {
            var entity = _phongBanRepository.FindAsync(x => x.ID == command.ID).Result;
            entity.Name = command.Name;
            _phongBanRepository.Update(entity);
            await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity.MapToPhongBanDto(_mapper);
        }
    }
}
