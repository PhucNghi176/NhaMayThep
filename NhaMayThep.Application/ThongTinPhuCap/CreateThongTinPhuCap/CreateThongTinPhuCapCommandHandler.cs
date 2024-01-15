using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateThongTinPhuCap
{
    public class CreateThongTinPhuCapCommandHandler : IRequestHandler<CreateThongTinPhuCapCommand, ThongTinPhuCapDTO>
    {
        private readonly IThongTinPhuCap _repository;
        private readonly IMapper _mapper;
        public CreateThongTinPhuCapCommandHandler(IThongTinPhuCap repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinPhuCapDTO> Handle(CreateThongTinPhuCapCommand request, CancellationToken cancellationToken)
        {
            var ThongTinPhuCap = new ThongTinPhuCapEntity
            {
                ID = request.id,
                Name = request.name,
                SoTienPhuCap = request.SoTienPhuCap,
            };
            _repository.Add(ThongTinPhuCap);
            await _repository.UnitOfWork.SaveChangesAsync();
            return ThongTinPhuCap.MapToThongTinPhuCapDTO(_mapper);
        }
    }
}
