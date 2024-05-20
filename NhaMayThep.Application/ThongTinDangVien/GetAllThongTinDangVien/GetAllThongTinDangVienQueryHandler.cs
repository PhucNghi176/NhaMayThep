using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien
{
    public class GetAllThongTinDangVienQueryHandler : IRequestHandler<GetAllThongTinDangVienQuery, List<ThongTinDangVienDto>>
    {
        private readonly IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinDangVienQueryHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinDangVienDto>> Handle(GetAllThongTinDangVienQuery request, CancellationToken cancellationToken)
        {
            var thongTinDangVienList = await _thongTinDangVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            return thongTinDangVienList.MapToThongTinDangVienDtoList(_mapper);
        }
    }
}
