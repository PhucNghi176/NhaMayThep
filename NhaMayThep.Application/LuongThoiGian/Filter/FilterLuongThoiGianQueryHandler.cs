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

namespace NhaMayThep.Application.LuongThoiGian.Filter
{
    public class FilterLuongThoiGianQueryHandler : IRequestHandler<FilterLuongThoiGIanQuery, PagedResult<LuongThoiGianDto>>
    {
        private readonly ILuongThoiGianRepository _luongThoiGianRepository;
        private readonly IMapper _mapper;

        public FilterLuongThoiGianQueryHandler(ILuongThoiGianRepository luongThoiGianRepository, IMapper mapper)
        {
            _luongThoiGianRepository = luongThoiGianRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LuongThoiGianDto>> Handle(FilterLuongThoiGIanQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LuongThoiGianEntity>, IQueryable<LuongThoiGianEntity>> option = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);

                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));

                if (!string.IsNullOrEmpty(request.HoVaTen))
                    query = query.Where(x => x.NhanVien.HoVaTen.Equals(request.HoVaTen));

                if (request.LuongNam != null)
                    query = query.Where(x => x.LuongNam == request.LuongNam);

                if (request.LuongThang != null)
                    query = query.Where(x => x.LuongThang == request.LuongThang);

                if (request.LuongTuan != null)
                    query = query.Where(x => x.LuongTuan == request.LuongTuan);

                if (request.LuongNgay != null)
                    query = query.Where(x => x.LuongNgay == request.LuongNgay);

                if (request.LuongGio != null)
                    query = query.Where(x => x.LuongGio == request.LuongGio);

                if (request.NgayApDung.HasValue)
                    query = query.Where(x => x.NgayApDung == request.NgayApDung);

                return query;
            };

            var list = await _luongThoiGianRepository.FindAllAsync(request.PageNo, request.PageSize, option, cancellationToken);

            if (!list.Any())
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");

            return PagedResult<LuongThoiGianDto>.Create
              (
              totalCount: list.TotalCount,
              pageCount: list.PageCount,
              pageSize: list.PageSize,
              pageNumber: list.PageNo,
              data: list.MapToLuongThoiGianDtoList(_mapper)
              );
        }
    }
}
