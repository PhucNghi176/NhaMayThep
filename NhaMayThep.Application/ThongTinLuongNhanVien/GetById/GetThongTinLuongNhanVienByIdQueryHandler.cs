using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByIdQueryHandler : IRequestHandler<GetThongTinLuongNhanVienByIdQuery, ThongTinLuongNhanVienDTO>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly IMapper _mapper;

        public GetThongTinLuongNhanVienByIdQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDTO> Handle(GetThongTinLuongNhanVienByIdQuery request, CancellationToken cancellationToken)
        {

            var thongtin = await _thongTinLuongNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (thongtin is null || thongtin.NgayXoa.HasValue)
            {
                throw new NotFoundException("Thông Tin không tìm thấy hoặc đã bị xóa");
            }
            return thongtin.MapToThongTinLuongNhanVienDTO(_mapper);
        }
    }
}
