using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetById
{
    public class GetKhaiBaoTangLuongByIdQueryHandler : IRequestHandler<GetKhaiBaoTangLuongByIdQuery, KhaiBaoTangLuongDto>
    {
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly IMapper _mapper;

        public GetKhaiBaoTangLuongByIdQueryHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper)
        {
            _khaiBaoTangLuongRepository = khaiBaoTangLuongRepository;
            _mapper = mapper;
        }


        public async Task<KhaiBaoTangLuongDto> Handle(GetKhaiBaoTangLuongByIdQuery request, CancellationToken cancellationToken)
        {
            var k = await _khaiBaoTangLuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("Khai bao tang luong is not exist");
            }
            return k.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
