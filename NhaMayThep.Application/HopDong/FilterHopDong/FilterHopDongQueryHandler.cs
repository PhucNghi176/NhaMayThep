using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;
using AutoMapper;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;
using NhaMayThep.Infrastructure.Repositories;

namespace NhaMayThep.Application.HopDong.FilterHopDong
{
    public class FilterHopDongQueryHandler : IRequestHandler<FilterHopDongQuery, PagedResult<HopDongDto>>
    {
        private readonly IHopDongRepository _repository;
        private readonly INhanVienRepository _nhanVienrepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly ApplicationDbContext _context;
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;

        public FilterHopDongQueryHandler(IHopDongRepository repository, IMapper mapper, IChucVuRepository chucVuRepository, IChucDanhRepository chucDanhRepository, ApplicationDbContext context, IPhuCapRepository phuCapRepository, ILoaiHopDongReposity loaiHopDongRepository, INhanVienRepository nhanVienrepository)
        {
            _repository = repository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
            _chucDanhRepository = chucDanhRepository;
            _context = context;
            _phuCapRepository = phuCapRepository;
            _loaiHopDongRepository = loaiHopDongRepository;
            _nhanVienrepository = nhanVienrepository;
        }



        public async Task<PagedResult<HopDongDto>> Handle(FilterHopDongQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<HopDongEntity>, IQueryable<HopDongEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (request.LoaiHopDongID != 0)
                {
                    query = query.Where(x => x.LoaiHopDongID.Equals(request.LoaiHopDongID));
                }
                if (request.NgayKy != null)
                {
                    query = query.Where(x => x.NgayKy.Equals(request.NgayKy));
                }
                if (!string.IsNullOrEmpty(request.BoPhanLamViec))
                {
                    query = query.Where(x => x.BoPhanLamViec.Contains(request.BoPhanLamViec));
                }
                if (request.ChucVuID != 0)
                {
                    query = query.Where(x => x.ChucVuID.Equals(request.ChucVuID));
                }
                if (request.ChucDanhID != 0)
                {
                    query = query.Where(x => x.ChucDanhID.Equals(request.ChucDanhID));
                }
                if (!string.IsNullOrEmpty(request.PhuCapID))
                {
                    query = query.Where(x => x.PhuCapID.Equals(request.PhuCapID));
                }
                return query;
            };




            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy hợp đồng.");
            var loaihopdong = await _loaiHopDongRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var phucap = await _phuCapRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucdanh = await _chucDanhRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var nhanvien = await _nhanVienrepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.HoVaTen, cancellationToken);
            return PagedResult<HopDongDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToListHopDongDto(_mapper, chucvu, chucdanh, phucap, loaihopdong, nhanvien));
        }
    }
}
