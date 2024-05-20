using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.HopDong.GetByPagination
{
    public class GetHopDongByPaginationQueryHandler : IRequestHandler<GetHopDongByPaginationQuery, PagedResult<HopDongDto>>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        public GetHopDongByPaginationQueryHandler(IHopDongRepository hopDongRepository, IMapper mapper, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository, IPhuCapRepository phuCapRepository, ILoaiHopDongReposity loaiHopDongReposity, INhanVienRepository nhanVienRepository)
        {
            _hopDongRepository = hopDongRepository;
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _phuCapRepository = phuCapRepository;
            _loaiHopDongReposity = loaiHopDongReposity;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<HopDongDto>> Handle(GetHopDongByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _hopDongRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            var chucDanh = await _chucDanhRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var chucVu = await _chucVuRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var phuCap = await _phuCapRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var loaiHopDong = await _loaiHopDongReposity.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var nhanVien = await _nhanVienRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.HoVaTen, cancellationToken);
            var result = list.MapToListHopDongDto(_mapper, chucDanh, chucVu, phuCap, loaiHopDong, nhanVien);

            return PagedResult<HopDongDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: result
                );
        }
    }
}
