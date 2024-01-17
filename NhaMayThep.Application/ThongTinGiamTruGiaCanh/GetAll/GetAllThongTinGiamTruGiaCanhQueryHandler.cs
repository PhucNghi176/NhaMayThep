using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAll
{
    public class GetAllThongTinGiamTruGiaCanhQueryHandler : IRequestHandler<GetAllThongTinGiamTruGiaCanhQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinGiamTruGiaCanhQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetAllThongTinGiamTruGiaCanhQuery request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository
                .FindAllAsync(x=> x.NguoiXoaID == null && !x.NgayXoa.HasValue, 
                cancellationToken);
=======
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository.FindAllAsync(x => x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
>>>>>>> origin/main
            if (giamtrugiacanhs == null || !giamtrugiacanhs.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin giảm trừ gia cảnh nào");
            }
            return giamtrugiacanhs.MapToThongTinGiamTruGiaCanhDtoList(_mapper);
        }
    }
}
