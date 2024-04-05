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

namespace NhaMayThep.Application.LuongCongNhat.Filter
{
    public class FilterLuongCongNhatQueryHandler : IRequestHandler<FilterLuongCongNhatQuery, PagedResult<LuongCongNhatDto>>
    {
        private readonly ILuongCongNhatRepository _luongCongNhatRepository;
        private readonly IMapper _mapper;
        public FilterLuongCongNhatQueryHandler(ILuongCongNhatRepository luongCongNhatRepository, IMapper mapper)
        {
            _luongCongNhatRepository = luongCongNhatRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LuongCongNhatDto>> Handle(FilterLuongCongNhatQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LuongCongNhatEntity>, IQueryable<LuongCongNhatEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);

                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));
                
                if(request.SoGioLam != null) 
                    query = query.Where(x => x.SoGioLam == request.SoGioLam);

                if(request.Luong1Gio != null)
                    query = query.Where(x => x.Luong1Gio == request.Luong1Gio);

                return query;
            };

            var list = await _luongCongNhatRepository.FindAllAsync(request.PageNo, request.PageSize, options, cancellationToken);

            if (!list.Any())
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");

            return PagedResult<LuongCongNhatDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLuongCongNhatDtoList(_mapper)
                );
        }
    }
}
