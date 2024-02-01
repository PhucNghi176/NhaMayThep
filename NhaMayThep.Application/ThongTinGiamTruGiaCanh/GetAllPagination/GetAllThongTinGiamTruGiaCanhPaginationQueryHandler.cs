using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPagination
{
    public class GetAllThongTinGiamTruGiaCanhPaginationQueryHandler : IRequestHandler<GetAllThongTinGiamTruGiaCanhPaginationQuery, PagedResult<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinGiamTruGiaCanhPaginationQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper,
            INhanVienRepository nhanVienRepository,
            IThongTinGiamTruRepository thongTinGiamTruRepository)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
        }
        public async Task<PagedResult<ThongTinGiamTruGiaCanhDto>> Handle(GetAllThongTinGiamTruGiaCanhPaginationQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository
                .FindAllAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue,
                request.PageNumber, request.PageSize, cancellationToken);
            var thongtingiamtrus = await _thongTinGiamTruRepository
                .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            if (giamtrugiacanhs == null || !giamtrugiacanhs.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin giảm trừ gia cảnh nào");
            }
            var resultList = giamtrugiacanhs.MapToThongTinGiamTruGiaCanhDtoList(_mapper, nhanviens, thongtingiamtrus);
            return PagedResult<ThongTinGiamTruGiaCanhDto>.Create(
               totalCount: giamtrugiacanhs.TotalCount,
               pageCount: giamtrugiacanhs.PageCount,
               pageSize: giamtrugiacanhs.PageSize,
               pageNumber: giamtrugiacanhs.PageNo,
               data: resultList);
        }
    }
}
