using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiCongTac.GetAll;
using NhaMayThep.Application.LoaiCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec
{
    public class GetAllTrangThaiDangKiCaLamViecHandler : IRequestHandler<GetAllTrangThaiDangKiCaLamViecQuery, List<TrangThaiDangKiCaLamViecDTO>>
    {
        private readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;
        private readonly IMapper _mapper;

        public GetAllTrangThaiDangKiCaLamViecHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, IMapper mapper)
        {
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
            _mapper = mapper;
        }

        public async Task<List<TrangThaiDangKiCaLamViecDTO>> Handle(GetAllTrangThaiDangKiCaLamViecQuery request, CancellationToken cancellationToken)
        {
            var list = await _trangThaiDangKiCaLamViecRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToTrangThaiDangKiCaLamViecDTOList(_mapper);
        }
    }
}
