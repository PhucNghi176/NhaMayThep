using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.BaoHiem.GetBaoHiemById
{
    public class GetBaoHiemByIdQueryHandler : IRequestHandler<GetBaoHiemByIdQuery, BaoHiemDto>
    {
        private readonly IBaoHiemRepository _baoHiemRepostory;
        private readonly IMapper _mapper;
        public GetBaoHiemByIdQueryHandler(IBaoHiemRepository baoHiemRepostory, IMapper mapper)
        {
            _baoHiemRepostory = baoHiemRepostory;
            _mapper = mapper;
        }

        public async Task<BaoHiemDto> Handle(GetBaoHiemByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _baoHiemRepostory.FindAsync(x => x.ID == query.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy bảo hiểm với id: {query.Id}");
            else
                return result.MapToBaoHiemDto(_mapper);
        }
    }
}
