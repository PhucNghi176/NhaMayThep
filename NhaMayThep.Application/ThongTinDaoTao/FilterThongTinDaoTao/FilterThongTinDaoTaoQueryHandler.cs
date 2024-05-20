using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinDaoTao.FilterThongTinDaoTao
{
    public class FilterThongTinDaoTaoQueryHandler : IRequestHandler<FilterThongTinDaoTaoQuery, PagedResult<ThongTinDaoTaoDto>>
    {
        private readonly IThongTinDaoTaoRepository _repository;
        private readonly IMapper _mapper;
        public FilterThongTinDaoTaoQueryHandler(IThongTinDaoTaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ThongTinDaoTaoDto>> Handle(FilterThongTinDaoTaoQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ThongTinDaoTaoEntity>, IQueryable<ThongTinDaoTaoEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (request.TrinhDoVanHoa != 0)
                {
                    query = query.Where(x => x.TrinhDoVanHoa.Equals(request.TrinhDoVanHoa));
                }
                if (request.MaTrinhDoHocVanID != 0)
                {
                    query = query.Where(x => x.MaTrinhDoHocVanID.Equals(request.MaTrinhDoHocVanID));
                }
                if (!string.IsNullOrEmpty(request.NhanVienID))
                {
                    query = query.Where(x => x.NhanVienID.Equals(request.NhanVienID));
                }
                if (!string.IsNullOrEmpty(request.TenTruong))
                {
                    query = query.Where(x => x.TenTruong.Contains(request.TenTruong));
                }
                if (!string.IsNullOrEmpty(request.ChuyenNganh))
                {
                    query = query.Where(x => x.ChuyenNganh.Contains(request.ChuyenNganh));
                }
                if (request.NamTotNghiep.HasValue)
                {
                    query = query.Where(x => x.NamTotNghiep.Equals(request.NamTotNghiep));
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy thông tin đào tạo.");

            return PagedResult<ThongTinDaoTaoDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.Select(x => _mapper.Map<ThongTinDaoTaoDto>(x)).ToList());
        }
    }
}
