using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetThongTinGiamTruGiaCanh
{
    public class GetThongTinGiamTruGiaCanhQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhQuery, ThongTinGiamTruGiaCanhDto>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhQueryHandler(
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinGiamTruGiaCanhDto> Handle(GetThongTinGiamTruGiaCanhQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository.FindById(request.Id, cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException("GiamTruGiaCanh does not exists");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDto(_mapper);
        }
    }
}
