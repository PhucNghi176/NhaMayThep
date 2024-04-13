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
            var nhanviens = await _nhanvienRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            var baohiems = await _baohiemRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            return result.MapToChiTietBaoHiemDtoList(_mapper, nhanviens, baohiems);
        }
    }
}
