using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommandHandler : IRequestHandler<CreateLoaiHoaDonCommand, LoaiHoaDonDto>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository,
            ICurrentUserService currentUserService, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<LoaiHoaDonDto> Handle(CreateLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = new LoaiHoaDonEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };

            _LoaiHoaDonRepository.Add(loaiHoaDon);
            await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiHoaDon.MapToLoaiHoaDonDto(_mapper);
        }
    }
}
