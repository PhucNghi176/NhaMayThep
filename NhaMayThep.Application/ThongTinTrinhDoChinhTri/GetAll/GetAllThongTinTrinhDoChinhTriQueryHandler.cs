using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.GetAll
{
    public class GetAllThongTinTrinhDoChinhTriQueryHandler : IRequestHandler<GetAllThongTinTrinhDoChinhTriQuery, List<ThongTinTrinhDoChinhTriDto>>
    {
        private readonly IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinTrinhDoChinhTriQueryHandler(IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository, IMapper mapper)
        {
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinTrinhDoChinhTriDto>> Handle(GetAllThongTinTrinhDoChinhTriQuery query, CancellationToken cancellationToken)
        {
            var thongTinTrinhDoChinhTriList = await _thongTinTrinhDoChinhTriRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (thongTinTrinhDoChinhTriList == null || !thongTinTrinhDoChinhTriList.Any())
            {
                throw new NotFoundException("Không có thông tin trình độ chính trị nào!");
            }
            return thongTinTrinhDoChinhTriList.MapToThongTinTrinhDoChinhTriDtoList(_mapper);
        }
    }
}
