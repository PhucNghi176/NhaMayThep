using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQueryHandler : IRequestHandler<GetAllKhaiBaoTangLuongQuery, List<KhaiBaoTangLuongDto>>
    {
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly IMapper _mapper;

        public GetAllKhaiBaoTangLuongQueryHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper)
        {
            _khaiBaoTangLuongRepository = khaiBaoTangLuongRepository;
            _mapper = mapper;
        }


        public async Task<List<KhaiBaoTangLuongDto>> Handle(GetAllKhaiBaoTangLuongQuery request, CancellationToken cancellationToken)
        {
            var ks = await _khaiBaoTangLuongRepository.FindAllAsync(cancellationToken);

            if (ks == null)
            {
                throw new NotFoundException("The list is empty");
            }
            var ksReturn = ks.Where(x => x.NgayXoa == null).ToList();
            return ksReturn.MapToKhaiBaoTangLuongDtoList(_mapper);
        }
    }
}
