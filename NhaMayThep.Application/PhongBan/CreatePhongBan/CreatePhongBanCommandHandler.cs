using MediatR;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Entities.ConfigTable;

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
