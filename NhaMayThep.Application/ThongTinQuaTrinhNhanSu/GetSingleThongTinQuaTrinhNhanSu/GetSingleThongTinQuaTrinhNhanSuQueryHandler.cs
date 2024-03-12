using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu
{
    public class GetSingleThongTinQuaTrinhNhanSuQueryHandler : IRequestHandler<GetSingleThongTinQuaTrinhNhanSuQuery, ThongTinQuaTrinhNhanSuDto>
    {
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        private readonly IMapper _mapper;
        public GetSingleThongTinQuaTrinhNhanSuQueryHandler(IMapper mapper, IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _mapper = mapper;
            _thongTinQuaTrinhNhanSu = thongTinQuaTrinhNhanSuRepository;   
        }
        public async Task<ThongTinQuaTrinhNhanSuDto> Handle(GetSingleThongTinQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var entity = await _thongTinQuaTrinhNhanSu.FindAsync(x => x.ID == request.ID && x.NguoiXoaID == null, cancellationToken);
            return entity.MapToThongTinQuaTrinhNhanSuDto(_mapper);
        }
    }
}
