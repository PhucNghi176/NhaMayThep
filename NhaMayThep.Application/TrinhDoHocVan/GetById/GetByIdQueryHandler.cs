using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TrinhDoHocVan.GetById
{
    public class GetByIdTrinhDoHocVanQueryHandler : IRequestHandler<GetByIdQuery, TrinhDoHocVanDto>
    {
        private readonly IMapper _mapper;
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;

        public GetByIdTrinhDoHocVanQueryHandler(IMapper mapper, ITrinhDoHocVanRepository trinhDoHocVanRepository)
        {
            _mapper = mapper;
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<TrinhDoHocVanDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var trinhDoHocVan = await _trinhDoHocVanRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (trinhDoHocVan == null || trinhDoHocVan.NgayXoa != null)
            {
                throw new NotFoundException("Trình Độ Học Vấn Không Tồn Tại!");
            }
            return trinhDoHocVan.MapToTrinhDoHocVanDto(_mapper);
        }
    }
}
