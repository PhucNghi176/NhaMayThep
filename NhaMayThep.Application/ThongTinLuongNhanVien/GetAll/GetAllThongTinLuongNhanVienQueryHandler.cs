using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetAll
{
    public class GetAllThongTinLuongNhanVienQueryHandler : IRequestHandler<GetAllThongTinLuongNhanVienQuery, List<ThongTinLuongNhanVienDTO>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinLuongNhanVienQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _mapper = mapper;
        }


        public async Task<List<ThongTinLuongNhanVienDTO>> Handle(GetAllThongTinLuongNhanVienQuery request, CancellationToken cancellationToken)
        {

            var list = await _thongTinLuongNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToThongTinLuongNhanVienDtoList(_mapper);
        }
    }
}
