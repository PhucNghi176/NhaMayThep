using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository.FindAllAsync(x=> x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (giamtrugiacanhs == null || !giamtrugiacanhs.Any())
            {
                throw new NotFoundException("Does not any ThongTinGiamTruGiaCanh exists");
            }
            return giamtrugiacanhs.MapToThongTinGiamTruGiaCanhDtoList(_mapper);
        }
    }
}
