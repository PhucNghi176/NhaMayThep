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

namespace NhaMayThep.Application.LichSuCongTacNhanVien.FilterLichSuCongTac
{
    public class FilterLichSuCongTacQueryHandler : IRequestHandler<FilterLichSuCongTacQuery, PagedResult<LichSuCongTacNhanVienDto>>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public FilterLichSuCongTacQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LichSuCongTacNhanVienDto>> Handle(FilterLichSuCongTacQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LichSuCongTacNhanVienEntity>, IQueryable<LichSuCongTacNhanVienEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);

                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));

                if (!string.IsNullOrEmpty(request.LoaiCongTac))
                    query = query.Where(x => x.LoaiCongTac.Name == request.LoaiCongTac);

                if (request.NgayBatDau != null)
                    query = query.Where(x => x.NgayBatDau.Equals(request.NgayBatDau));

                if (request.NgayKetThuc != null)
                    query = query.Where(x => x.NgayKetThuc.Equals(request.NgayKetThuc));

                if (!string.IsNullOrEmpty(request.NoiCongTac))
                    query = query.Where(x => x.NoiCongTac.Equals(request.NoiCongTac));

                return query;
            };

            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!list.Any())
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");
            return list.MapToPagedResult(x => x.MapToLichSuCongTacNhanVienDto(_mapper));
        }
    }
}
