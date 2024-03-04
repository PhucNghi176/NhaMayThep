﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetById
{
    public class GetChiTietBaoHiemByIdQueryHandler : IRequestHandler<GetChiTietBaoHiemByIdQuery, ChiTietBaoHiemDto>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly IMapper _mapper;
        public GetChiTietBaoHiemByIdQueryHandler(IChiTietBaoHiemRepository chitietbaohiemRepository, IMapper mapper)
        {
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _mapper = mapper;
        }

        public async Task<ChiTietBaoHiemDto> Handle(GetChiTietBaoHiemByIdQuery request, CancellationToken cancellationToken)
        {
            var checkExistsEntity = await _chitietbaohiemRepository.FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null & !x.NgayXoa.HasValue, cancellationToken);
            if(checkExistsEntity == null) 
            {
                throw new NotFoundException($"Không tìm thấy chi tiết bảo hiểm với Id '{request.Id}'");
            }
            return checkExistsEntity.MapToChiTietBaoHiemDto(_mapper, checkExistsEntity.NhanVien.HoVaTen, checkExistsEntity.BaoHiem.Name);
        }
    }
}