using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandHandler : IRequestHandler<CreateTinhTrangLamViecCommand, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateTinhTrangLamViecCommandHandler(ITinhTrangLamViecRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public CreateTinhTrangLamViecCommandHandler() { }
        public async Task<TinhTrangLamViecDTO> Handle(CreateTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = new TinhTrangLamViecEntity
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow
            };
            _repository.Add(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
