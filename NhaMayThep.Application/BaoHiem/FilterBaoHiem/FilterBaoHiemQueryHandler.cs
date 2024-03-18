using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.FilterBaoHiem
{
    public class FilterBaoHiemQueryHandler : IRequestHandler<FilterBaoHiemQuery, PagedResult<BaoHiemDto>>
    {
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public FilterBaoHiemQueryHandler(IBaoHiemRepository baohiemRepository, IMapper mapper)
        {
            _baohiemRepository = baohiemRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<BaoHiemDto>> Handle(FilterBaoHiemQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<BaoHiemEntity>, IQueryable<BaoHiemEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);
                if(request.Id != 0)
                {
                    query = query.Where(x => x.ID == request.Id);
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Search(x => x.Name).Containing(request.Name);
                }
                if(request.Discount != 0)
                {
                    query = query.Where(x => x.PhanTramKhauTru == request.Discount);
                }
                return query;
            };

            var listResult = await _baohiemRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!listResult.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");
            }
            return listResult.MapToPagedResult(x => x.MapToBaoHiemDto(_mapper));
        }
    }
}
