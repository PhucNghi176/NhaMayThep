using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetAllThongTinQuaTrinhNhanSu
{
    public class GetAllThongTinQuaTrinhNhanSuQueryHandler : IRequestHandler<GetAllThongTinQuaTrinhNhanSuQuery, List<ThongTinQuaTrinhNhanSuDto>>
    {
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        private readonly IMapper _mapper;
        public GetAllThongTinQuaTrinhNhanSuQueryHandler(IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository, IMapper mapper)
        {
            _thongTinQuaTrinhNhanSu = thongTinQuaTrinhNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinQuaTrinhNhanSuDto>> Handle(GetAllThongTinQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var entity = await _thongTinQuaTrinhNhanSu.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy thông tin quá trình nhân sự nào");
            }
            return entity.MapToThongTinQuaTrinhNhanSuDtoList(_mapper);
        }
    }
}
