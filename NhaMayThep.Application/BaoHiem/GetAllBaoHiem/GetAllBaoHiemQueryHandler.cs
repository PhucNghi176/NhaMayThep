﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.GetAllBaoHiem
{
    public class GetAllBaoHiemQueryHandler : IRequestHandler<GetAllBaoHiemQuery, List<BaoHiemDto>>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly IMapper _mapper;
        public GetAllBaoHiemQueryHandler(IBaoHiemRepository baoHiemRepository, IMapper mapper)
        {
            _baoHiemRepository = baoHiemRepository;
            _mapper = mapper;
        }
        public async Task<List<BaoHiemDto>> Handle(GetAllBaoHiemQuery query, CancellationToken cancellationToken)
        {
            var list = await _baoHiemRepository.FindAllAsync(cancellationToken);
            List<BaoHiemDto> result = new List<BaoHiemDto>();
            foreach (var item in list)
            {
                if (item.NgayXoa != null)
                    continue;
                var add = item.MapToBaoHiemDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
