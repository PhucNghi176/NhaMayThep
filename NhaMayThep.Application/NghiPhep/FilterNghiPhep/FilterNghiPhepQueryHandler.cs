using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.FilterNghiPhep
{
    public class FilterNghiPhepQueryHandler : IRequestHandler<FilterNghiPhepQuery, PagedResult<NghiPhepDto>>
    {
        private readonly INghiPhepRepository _repository;
        private readonly IMapper _mapper;

        public FilterNghiPhepQueryHandler(INghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NghiPhepDto>> Handle(FilterNghiPhepQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<NghiPhepEntity>, IQueryable<NghiPhepEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));
                }
                if (request.LoaiNghiPhepID.HasValue && request.LoaiNghiPhepID != 0)
                {
                    query = query.Where(x => x.LoaiNghiPhepID == request.LoaiNghiPhepID);
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin nghỉ phép.");
            }

            return PagedResult<NghiPhepDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.Select(x => _mapper.Map<NghiPhepDto>(x)).ToList());
        }
    }
}
