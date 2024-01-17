using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThonTinGiamTruGiaCanhByNhanVienIdQueryHandler : IRequestHandler<GetThonTinGiamTruGiaCanhByNhanVienIdQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThonTinGiamTruGiaCanhByNhanVienIdQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetThonTinGiamTruGiaCanhByNhanVienIdQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository.FindAllAsync(x => x.NhanVienID.Equals(request.Id) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException($"No GiamTruGiaCanh found for the NhanVien with Id: {request.Id}");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDtoList(_mapper);
        }
    }
}
