using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinCapDangVien.GetAll
{
    public class GetAllThongTinCapDangVienQueryHandler : IRequestHandler<GetAllThongTinCapDangVienQuery, List<ThongTinCapDangVienDto>>
    {
        private readonly IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinCapDangVienQueryHandler(IThongTinCapDangVienRepository thongTinCapDangVienRepository, IMapper mapper)
        {
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinCapDangVienDto>> Handle(GetAllThongTinCapDangVienQuery query, CancellationToken cancellationToken)
        {
            var thongTinCapDangVienList = await _thongTinCapDangVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (thongTinCapDangVienList == null || !thongTinCapDangVienList.Any())
            {
                throw new NotFoundException("Không có thông tin cấp đảng viên nào!");
            }
            return thongTinCapDangVienList.MapToThongTinCapDangVienDtoList(_mapper);
        }
    }
}
