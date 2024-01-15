using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.PhongBan.CreatePhongBan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQueryHandler : IRequestHandler<GetPhongBanQuery, PhongBanDto>
    {
        IMapper _mapper;
        IPhongBanRepository _phongBanRepository;
        public GetPhongBanQueryHandler(IMapper mapper, IPhongBanRepository phongBanRepository)
        {
            _mapper = mapper;
            _phongBanRepository = phongBanRepository;
        }
        public async Task<PhongBanDto> Handle(GetPhongBanQuery request, CancellationToken cancellationToken)
        {
            var phongBan =  _phongBanRepository.FindAsync(x => x.ID == request.ID).Result;
            return phongBan.MapToPhongBanDto(_mapper);
        }
    }
}
