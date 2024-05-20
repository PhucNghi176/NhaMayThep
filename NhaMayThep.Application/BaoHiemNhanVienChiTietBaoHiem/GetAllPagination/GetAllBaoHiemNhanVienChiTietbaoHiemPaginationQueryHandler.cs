using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllPagination
{
    public class GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQueryHandler : IRequestHandler<GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery, PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly IMapper _mapper;
        public GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQueryHandler(IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository, IMapper mapper)
        {
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>> Handle(GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery request, CancellationToken cancellationToken)
        {
            var listExists = await _baohiemNhanVienChiTietRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (listExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bảo hiểm nào");
            }
            return listExists.MapToPagedResult(x => x.MapFullToBaoHiemNhanVienChiTietDto(_mapper));
        }
    }
}
