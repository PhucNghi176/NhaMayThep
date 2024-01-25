using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQueryHandler : IRequestHandler<GetAllKhaiBaoTangLuongQuery, List<KhaiBaoTangLuongDto>>
    {
        private readonly IKhaiBaoTangLuongRepository _KhaiBaoTangLuongRepository;
        private readonly IMapper _mapper;

        public GetAllKhaiBaoTangLuongQueryHandler(IKhaiBaoTangLuongRepository KhaiBaoTangLuongRepository, IMapper mapper)
        {
            _KhaiBaoTangLuongRepository = KhaiBaoTangLuongRepository;
            _mapper = mapper;
        }

        public async Task<List<KhaiBaoTangLuongDto>> Handle(GetAllKhaiBaoTangLuongQuery request, CancellationToken cancellationToken)
        {

            var KhaiBaoTangLuongList = await _KhaiBaoTangLuongRepository.FindAllAsync(cancellationToken);
            return KhaiBaoTangLuongList.MapToKhaiBaoTangLuongDtoList(_mapper);
        }
    }
}
