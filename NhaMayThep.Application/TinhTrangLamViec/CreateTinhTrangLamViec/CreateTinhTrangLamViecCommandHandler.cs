using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandHandler : IRequestHandler<CreateTinhTrangLamViecCommand, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly IMapper _mapper;
        public CreateTinhTrangLamViecCommandHandler(ITinhTrangLamViec repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TinhTrangLamViecDTO> Handle(CreateTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = new TinhTrangLamViecEntity
            {
                ID = request.ID,
                Name = request.Name,
                NguoiTaoID = request.NguoiTaoID,
                NgayTao = DateTime.UtcNow
            };
            _repository.Add(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
