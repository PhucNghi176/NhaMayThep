using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetTrangThaiDangKiCaLamViecById
{
    public class GetTrangThaiDangKiCaLamViecByIdHandler : IRequestHandler<GetTrangThaiDangKiCaLamViecByIdQuery, TrangThaiDangKiCaLamViecDTO>
    {
        private readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;
        private readonly IMapper _mapper;

        public GetTrangThaiDangKiCaLamViecByIdHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, IMapper mapper)
        {
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
            _mapper = mapper;
        }

        public async Task<TrangThaiDangKiCaLamViecDTO> Handle(GetTrangThaiDangKiCaLamViecByIdQuery request, CancellationToken cancellationToken)
        {
            var trangThai = await _trangThaiDangKiCaLamViecRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (trangThai is null || trangThai.NgayXoa.HasValue)
            {
                throw new NotFoundException("Trạng Thái không tìm thấy hoặc đã bị xóa");
            }
            return trangThai.MapToTrangThaiDangKiCaLamViecDTO(_mapper);
        }
    }
}
