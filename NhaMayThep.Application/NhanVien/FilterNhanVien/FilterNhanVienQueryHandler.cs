using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID
{
    public class FilterNhanVienQueryHandler : IRequestHandler<FilterNhanVienQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public FilterNhanVienQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterNhanVienQuery request, CancellationToken cancellationToken)
        {

            Func<IQueryable<NhanVienEntity>, IQueryable<NhanVienEntity>> queryOptions = query =>
            {
                if (request.chucvuID != 0)
                {
                    query = query.Where(x => x.ChucVuID.Equals(request.chucvuID));
                }
                if (request.tinhtranglamviecID != 0)
                {
                    query = query.Where(x => x.TinhTrangLamViecID.Equals(request.tinhtranglamviecID));
                }
                if (!string.IsNullOrEmpty(request.HoVaTen))
                {
                    query = query.Where(x => x.HoVaTen.Contains(request.HoVaTen));
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(x => x.Email.Contains(request.Email));
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions);
            if (result.Count() == 0)
                throw new NotFoundException("Không tìm thấy nhân viên.");
            return PagedResult<NhanVienDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToNhanVienDtoList(_mapper));




        }
    }
}
