using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQueryHandler : IRequestHandler<GetPhongBanQuery, PhongBanDto>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        public GetPhongBanQueryHandler(IMapper mapper, IPhongBanRepository phongBanRepository)
        {
            _mapper = mapper;
            _phongBanRepository = phongBanRepository;
        }
        public async Task<PhongBanDto> Handle(GetPhongBanQuery request, CancellationToken cancellationToken)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == request.ID).Result;
            return phongBan.MapToPhongBanDto(_mapper);
        }
    }
}
