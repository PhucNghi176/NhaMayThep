using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommandHandler : IRequestHandler<CreateLoaiCongTacCommand>
    {
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public CreateLoaiCongTacCommandHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateLoaiCongTacCommand request, CancellationToken cancellationToken)
        {
            var loaiCongTac = new LoaiCongTacEntity()
            {
                Name=request.Name
            };
            _loaiCongTacRepository.Add(loaiCongTac);
            await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
        }
    }
}
