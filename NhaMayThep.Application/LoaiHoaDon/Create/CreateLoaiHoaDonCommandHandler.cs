using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommandHandler : IRequestHandler<CreateLoaiHoaDonCommand, string>
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

        public async Task<string> Handle(CreateLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var exist = await _LoaiHoaDonRepository.FindAsync(x => x.Name == request.Name && !x.NgayTao.HasValue, cancellationToken);
            if(exist != null) 
            {
                throw new NotFoundException("Loại Hóa Đơn trên đã tồn tại!");
            }
            var loaiHoaDon = new LoaiHoaDonEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };

            _LoaiHoaDonRepository.Add(loaiHoaDon);
            await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo Mới Thành Công";
        }
    }
}
