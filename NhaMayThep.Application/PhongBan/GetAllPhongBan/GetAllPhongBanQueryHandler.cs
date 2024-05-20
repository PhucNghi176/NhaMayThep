using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.GetAllPhongBan
{
    public class GetAllPhongBanQueryHandler : IRequestHandler<GetAllPhongBanQuery, List<PhongBanDto>>
    {
        private readonly IPhongBanRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPhongBanQueryHandler(IPhongBanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetAllPhongBanQueryHandler() { }
        public async Task<List<PhongBanDto>> Handle(GetAllPhongBanQuery request, CancellationToken cancellationToken)
        {
            var phongban = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (phongban == null)
                throw new NotFoundException("Không tìm thấy bất kỳ phòng ban nào.");
            return phongban.MapToPhongBanDtoList(_mapper);
        }
    }
}
