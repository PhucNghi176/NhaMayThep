using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetAll
{
    public class GetAllBaoHiemNhanVienQueryHandler : IRequestHandler<GetAllQuery, List<BaoHiemNhanVienDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;

        public GetAllBaoHiemNhanVienQueryHandler(IMapper mapper, IBaoHiemNhanVienRepository baoHiemNhanVienRepository)
        {
            _mapper = mapper;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
        }

        public async Task<List<BaoHiemNhanVienDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listBaoHiemNhanVien = await _baoHiemNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (listBaoHiemNhanVien == null || listBaoHiemNhanVien.Count == 0)
            {
                throw new NotFoundException("Không có Bảo Hiểm Nhân Viên nào!");
            }
            return _mapper.Map<List<BaoHiemNhanVienDto>>(listBaoHiemNhanVien);
        }
    }
}
