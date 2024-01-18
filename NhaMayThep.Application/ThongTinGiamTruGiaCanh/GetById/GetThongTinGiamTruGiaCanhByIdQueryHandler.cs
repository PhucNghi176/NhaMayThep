using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById
{
    public class GetThongTinGiamTruGiaCanhByIdQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhByIdQuery, ThongTinGiamTruGiaCanhDto>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhByIdQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinGiamTruGiaCanhDto> Handle(GetThongTinGiamTruGiaCanhByIdQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository
                .FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null && !x.NgayXoa.HasValue, 
                cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException("Thông tin giảm trừ gia cảnh không tồn tại");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDto(_mapper);
        }
    }
}
