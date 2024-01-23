using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetPaginationChucVu
{
    public class GetChucVuByPaginationQueryHandler : IRequestHandler<GetChucVuByPaginationQuery, PagedResult<ChucVuDto>>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetChucVuByPaginationQueryHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChucVuDto>> Handle(GetChucVuByPaginationQuery query, CancellationToken cancellationToken)
        {
            var count = await _chucVuRepository.CountAsync(x => x.NgayXoa == null, cancellationToken);
            var page = (int)Math.Ceiling((decimal)count / query.PageSize);

            List<ThongTinChucVuEntity> allData = await _chucVuRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);

            var data = allData.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList();

            List<ChucVuDto> result = new List<ChucVuDto>();
            foreach (var item in data)
            {
                var add = item.MapToChucVuDto(_mapper);
                result.Add(add);
            }
            PagedResult<ChucVuDto> paged = PagedResult<ChucVuDto>.Create(totalCount: count,
                                                                         pageCount: page,
                                                                         pageSize: query.PageSize,
                                                                         pageNumber: query.PageNumber,
                                                                         data: result);
            return paged;
        }
    }
}
