using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHoaDon.Update
{
    public class UpdateLoaiHoaDonCommandHandler : IRequestHandler<UpdateLoaiHoaDonCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public UpdateLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = await _LoaiHoaDonRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiHoaDon == null || loaiHoaDon.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Hóa Đơn không tồn tại");
            }
            if (loaiHoaDon.Name.Equals(request.Name))
            {
                throw new DuplicationException("Loại Hóa Đơn Này Đã Tồn Tại");
            }
            loaiHoaDon.NguoiCapNhatID = _currentUserService.UserId;
            loaiHoaDon.Name = request.Name;
            loaiHoaDon.NgayCapNhat = DateTime.Now;
            _LoaiHoaDonRepository.Update(loaiHoaDon);
            await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Cập Nhật Thành Công";
        }
    }
}
