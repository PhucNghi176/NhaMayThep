using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAll
{
    public class GetAllChiTietBaoHiemQueryHandler : IRequestHandler<GetAllChiTietBaoHiemQuery, List<ChiTietBaoHiemDto>>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        public GetAllChiTietBaoHiemQueryHandler(
            IChiTietBaoHiemRepository chiTietBaoHiemRepository, 
            IMapper mapper,
            INhanVienRepository nhanVienRepository,
            IBaoHiemRepository baoHiemRepository)
        {
            _chitietbaohiemRepository = chiTietBaoHiemRepository;
            _mapper = mapper;
            _nhanvienRepository = nhanVienRepository;
            _baohiemRepository = baoHiemRepository;
        }
        public async Task<List<ChiTietBaoHiemDto>> Handle(GetAllChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var result = await _chitietbaohiemRepository.FindAllAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);
            if(result.Count == 0)
            {
                throw new NotFoundException("Không tồn tại bất kỳ chi tiết bảo hiểm nào");
            }
            var timer = new Stopwatch();

            timer.Start();
            var tasks = result.Select(async x =>
            {
                var nhanvien = await _nhanvienRepository.FindAsync(_ => _.ID.Equals(x.MaSoNhanVien) ,cancellationToken);
                var baohiem = await _baohiemRepository.FindAsync(_ => _.ID == x.LoaiBaoHiem, cancellationToken);
                if(nhanvien  != null && baohiem != null)
                {
                   return x.MapToChiTietBaoHiemDto(_mapper, nhanvien.HoVaTen, baohiem.Name);
                }
                else
                {
                   return x.MapToChiTietBaoHiemDto(_mapper, null, null);
                }
            });
            var mappedResults = await Task.WhenAll(tasks);
            timer.Stop();
            Console.Write("Elapsed Time 1: " + timer.Elapsed);
            timer.Reset();
            timer.Start();
            var nhanviens = await _nhanvienRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            var baohiems = await _baohiemRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            result.MapToChiTietBaoHiemDtoList(_mapper, nhanviens, baohiems);
            timer.Stop();
            Console.Write("Elapsed Time 2: " + timer.Elapsed);

            return mappedResults.ToList();
        }
    }
}
