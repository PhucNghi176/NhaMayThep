using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanByNhanVienID
{
    public class GetCanCuocCongDanByNhanVienIDQueryHandler : IRequestHandler<GetCanCuocCongDanByNhanVienIDQuery, CanCuocCongDanDto>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public GetCanCuocCongDanByNhanVienIDQueryHandler(ICanCuocCongDanRepository canCuocCongDanRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<CanCuocCongDanDto> Handle(GetCanCuocCongDanByNhanVienIDQuery request, CancellationToken cancellationToken)
        {
            var isNhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken);
            if (isNhanVien is null)
            {
                throw new NotFoundException($"Khong Tim Thay Nhan Vien {request.NhanVienID}");
            }
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken);
            if (CanCuocCongDan is null)
            {
                throw new NotFoundException($"Khong Tim Thay CanCuocCongDan {request.NhanVienID}");
            }
            return CanCuocCongDan.MapToCanCuocCongDanDto(_mapper);
        }
    }
}
