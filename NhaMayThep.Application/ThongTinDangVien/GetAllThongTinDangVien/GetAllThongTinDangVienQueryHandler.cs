﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien
{
    public class GetAllThongTinDangVienQueryHandler : IRequestHandler<GetAllThongTinDangVienQuery, List<ThongTinDangVienDto>>
    {
        private readonly IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinDangVienQueryHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinDangVienDto>> Handle(GetAllThongTinDangVienQuery request, CancellationToken cancellationToken)
        {

            var thongTinDangVienList = await _thongTinDangVienRepository.FindAllAsync(cancellationToken);
            return thongTinDangVienList.MapToThongTinDangVienDtoList(_mapper);
        }
    }
}