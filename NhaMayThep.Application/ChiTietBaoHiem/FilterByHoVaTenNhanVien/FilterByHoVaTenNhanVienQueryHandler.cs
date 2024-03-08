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

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterByHoVaTenNhanVienQueryHandler : IRequestHandler<FilterByHoVaTenNhanVienQuery, List<ChiTietBaoHiemDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public FilterByHoVaTenNhanVienQueryHandler(INhanVienRepository nhanVienRepository,IChiTietBaoHiemRepository chitietbaohiemRepository,
            IBaoHiemRepository baoHiemRepository, IMapper mapper)
        {
            _baohiemRepository = baoHiemRepository;
            _mapper = mapper;
            _nhanvienRepository = nhanVienRepository;
            _chitietbaohiemRepository = chitietbaohiemRepository;
        }
        public async Task<List<ChiTietBaoHiemDto>> Handle(FilterByHoVaTenNhanVienQuery request, CancellationToken cancellationToken)
        {
            string removeSpace = request.HoVaTen.Replace(" ", "").ToLower();
            var  array= removeSpace.ToArray();
            //var result = await _chitietbaohiemRepository.FindAllAsync(x => array.All(y => x.MaSoNhanVien.ToLower().Contains(y.ToString())),
            //    request.PageNumber, request.PageSize, cancellationToken);
            var resultQuery = await _chitietbaohiemRepository.FindAllAsync(x=> x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);

            var filter = resultQuery.Where(x => 
                array.All(y => x.NhanVien.HoVaTen.Replace(" ", "").ToLower().Contains(y.ToString())));
            var tasks = filter.Select(async x =>
            {
                var nhanvien = await _nhanvienRepository.FindAsync(_ => _.ID.Equals(x.MaSoNhanVien), cancellationToken);
                var baohiem = await _baohiemRepository.FindAsync(_ => _.ID == x.LoaiBaoHiem, cancellationToken);
                if (nhanvien != null && baohiem != null)
                {
                    return x.MapToChiTietBaoHiemDto(_mapper, nhanvien.HoVaTen, baohiem.Name);
                }
                else
                {
                    return x.MapToChiTietBaoHiemDto(_mapper, null, null);
                }
            });
            var mappedResults = await Task.WhenAll(tasks);
            if(mappedResults != null)
            {
                return mappedResults.ToList();
            }
            else
            {
                return new List<ChiTietBaoHiemDto>(){ };
            }
        }
    }
}
