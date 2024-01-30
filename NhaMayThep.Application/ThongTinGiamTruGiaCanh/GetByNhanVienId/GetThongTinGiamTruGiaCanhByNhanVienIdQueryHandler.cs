using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhByNhanVienIdQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        public GetThongTinGiamTruGiaCanhByNhanVienIdQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper,
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            INhanVienRepository nhanVienRepository)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetThongTinGiamTruGiaCanhByNhanVienIdQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository
                .FindAllAsync(x=> x.NhanVienID.Equals(request.Id) && x.NguoiXoaID== null && !x.NgayXoa.HasValue, cancellationToken);
            var thongtingiamtrus = await _thongTinGiamTruRepository
                .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            if (giamtrugiacanhs == null)
            {
                throw new NotFoundException($"Không tìm thấy bất kì thông tin giảm trừ gia cảnh của nhân viên với Id: {request.Id}");
            }
            return giamtrugiacanhs.MapToThongTinGiamTruGiaCanhDtoList(_mapper, nhanviens, thongtingiamtrus);
        }
    }
}
