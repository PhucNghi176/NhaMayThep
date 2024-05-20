using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeleted
{
    public class GetAllThongTinCongDoanDeletedQueryHandler : IRequestHandler<GetAllThongTinCongDoanDeletedQuery, List<ThongTinCongDoanDto>>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetAllThongTinCongDoanDeletedQueryHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper,
            INhanVienRepository nhanVienRepository)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<List<ThongTinCongDoanDto>> Handle(GetAllThongTinCongDoanDeletedQuery request, CancellationToken cancellationToken)
        {
            var thongtincongdoans = await _thongtinCongDoanRepository
                .FindAllAsync(x => x.NgayXoa.HasValue && x.NguoiXoaID != null, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue && x.NguoiXoaID == null, x => x.ID, x => x.HoVaTen, cancellationToken);
            if (thongtincongdoans == null || !thongtincongdoans.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công đoàn nào");
            }
            return thongtincongdoans.MapToThongTinCongDoanDtoList(_mapper, nhanviens);
        }
    }
}
