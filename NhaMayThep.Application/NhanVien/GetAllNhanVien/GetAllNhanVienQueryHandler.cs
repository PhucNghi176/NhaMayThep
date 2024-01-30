using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVien
{
    public class GetAllNhanVienQueryHandler : IRequestHandler<GetAllNhanVienQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        public GetAllNhanVienQueryHandler(INhanVienRepository nhanvienReopsitory, IMapper mapper, IChucVuRepository chucvuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository)
        {
            _nhanvienRepository = nhanvienReopsitory;
            _mapper = mapper;
            _chucVuRepository = chucvuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
        }

        public async Task<PagedResult<NhanVienDto>> Handle(GetAllNhanVienQuery request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var list = await _nhanvienRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var returnList = new List<NhanVienDto>();
            foreach (var item in list)
            {
                var chucVu = await _chucVuRepository.FindAnyAsync(x => x.ID == item.ChucVuID && x.NgayXoa == null, cancellationToken);
                var nvDto = _mapper.Map<NhanVienDto>(item);
                nvDto.ChucVu = chucVu.Name;
                returnList.Add(nvDto);
            }
            return returnList;
=======
>>>>>>> 4a42c6dbe295054f30a5fa8170df8aa4915eca03

            var list = await _nhanvienRepository.FindAllAsync(_ => _.NgayXoa == null, request.PageNumber, request.PageSize, cancellationToken);
            var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var tinhtranglamviec = await _tinhTrangLamViecRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var returnList = list.MapToNhanVienDtoList(_mapper, chucvu, tinhtranglamviec);

            return PagedResult<NhanVienDto>.Create(totalCount: list.TotalCount,
                               pageCount: list.PageCount,
                                              pageSize: list.PageSize,
                                                             pageNumber: list.PageNo,
                                                                            data: returnList);

        }
    }
}
