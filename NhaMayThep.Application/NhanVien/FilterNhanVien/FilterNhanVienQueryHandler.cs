using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Application.NhanVien.FilterNhanVien
{
    public class FilterNhanVienQueryHandler : IRequestHandler<FilterNhanVienQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        private readonly ApplicationDbContext _context;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;

        public FilterNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper, IChucVuRepository chucVuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository, ApplicationDbContext context, ICanCuocCongDanRepository canCuocCongDanRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
            _context = context;
            _canCuocCongDanRepository = canCuocCongDanRepository;
        }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterNhanVienQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<NhanVienEntity>, IQueryable<NhanVienEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
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
                if (!string.IsNullOrEmpty(request.CanCuocCongDan))
                {
                    query = query.Join(_context.CanCuocCongDan,
                          nhanVien => nhanVien.ID,
                          canCuoc => canCuoc.NhanVienID,
                          (nhanVien, canCuoc) => new { NhanVien = nhanVien, CanCuocCongDan = canCuoc })
                    .Where(x => x.CanCuocCongDan.CanCuocCongDan.Contains(request.CanCuocCongDan))
                    .Select(x => x.NhanVien);
                }
                return query;
            };




            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy nhân viên.");

            var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var tinhtranglamviec = await _tinhTrangLamViecRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.NhanVienID, x => x.CanCuocCongDan, cancellationToken);
            return PagedResult<NhanVienDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToNhanVienDtoList(_mapper, chucvu, tinhtranglamviec, CanCuocCongDan));




        }
    }
}
