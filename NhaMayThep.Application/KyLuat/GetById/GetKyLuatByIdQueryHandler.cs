using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KyLuat.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetById
{
    public class GetKyLuatByIdQueryHandler : IRequestHandler<GetKyLuatByIdQuery, KyLuatDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;

        public GetKyLuatByIdQueryHandler(IKyLuatRepository kyLuatRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
        }


        public async Task<KyLuatDto> Handle(GetKyLuatByIdQuery request, CancellationToken cancellationToken)
        {
            var k = await _kyLuatRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Ky Luat not found");
            }
            return k.MapToKyLuatDto(_mapper);
        }
    }
}
