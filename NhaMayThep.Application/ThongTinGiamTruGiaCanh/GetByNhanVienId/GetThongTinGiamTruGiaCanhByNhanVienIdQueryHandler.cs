using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhByNhanVienIdQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhByNhanVienIdQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetThongTinGiamTruGiaCanhByNhanVienIdQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository
                .FindAllAsync(x=> x.NhanVienID.Equals(request.Id) && x.NguoiXoaID== null && !x.NgayXoa.HasValue, cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException($"Không tìm thấy bất kì thông tin giảm trừ gia cảnh của nhân viên với Id: {request.Id}");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDtoList(_mapper);
        }
    }
}
