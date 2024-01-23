﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac
{
    public class GetAllDonViCongTacQueryHandler : IRequestHandler<GetAllDonViCongTacQuery, List<DonViCongTacDto>>
    {
        private readonly IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;

        public GetAllDonViCongTacQueryHandler(IDonViCongTacRepository donViCongTacRepository, IMapper mapper)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
        }

        public async Task<List<DonViCongTacDto>> Handle(GetAllDonViCongTacQuery request, CancellationToken cancellationToken)
        {

            var donViCongTacList = await _donViCongTacRepository.FindAllAsync(cancellationToken);
            return donViCongTacList.MapToDonViCongTacDtoList(_mapper);
        }
    }
}