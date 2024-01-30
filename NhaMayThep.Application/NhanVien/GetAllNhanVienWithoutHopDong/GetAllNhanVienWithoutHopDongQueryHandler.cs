using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVienWithoutHopDong
{
    public class GetAllNhanVienWithoutHopDongQueryHandler : IRequestHandler<GetAllNhanVienWithoutHopDongQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;

        public GetAllNhanVienWithoutHopDongQueryHandler(INhanVienRepository nhanVienRepository, IMapper mapper, IChucVuRepository chucVuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
        }

        public async Task<PagedResult<NhanVienDto>> Handle(GetAllNhanVienWithoutHopDongQuery request, CancellationToken cancellationToken)
        {
            var list = await _nhanVienRepository.FindAllAsync(_ => _.NgayXoa == null && !_.DaCoHopDong, request.PageNumber, request.PageSize, cancellationToken);
            //var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            //var tinhtranglamviec = await _tinhTrangLamViecRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var returnList = list.MapToNhanVienDtoList(_mapper/*, chucvu, tinhtranglamviec*/);
            return PagedResult<NhanVienDto>.Create(
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: returnList);
        }
    }
}
