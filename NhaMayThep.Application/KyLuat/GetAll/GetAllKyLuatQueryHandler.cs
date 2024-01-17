using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KyLuat.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetAll
{
    public class GetAllKyLuatQueryHandler : IRequestHandler<GetAllKyLuatQuery, List<KyLuatDto>>
    {
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;

        public GetAllKyLuatQueryHandler(IKyLuatRepository kyLuatRepository, IMapper mapper)
        {
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
        }


        public async Task<List<KyLuatDto>> Handle(GetAllKyLuatQuery request, CancellationToken cancellationToken)
        {
            var ks = await _kyLuatRepository.FindAllAsync(cancellationToken);

            if (ks == null )
            {
                throw new NotFoundException("The list is empty");
            }

            var ksReturn = ks.Where(x => x.NgayXoa == null).ToList();

            return ksReturn.MapToKyLuatDtoList(_mapper);
        }
    }
}
