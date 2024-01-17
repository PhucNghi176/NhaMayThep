using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhenThuong.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetById
{
    public class GetKhenThuongByIdQueryHandler : IRequestHandler<GetKhenThuongByIdQuery, KhenThuongDto>
    {
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;

        public GetKhenThuongByIdQueryHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper)
        {
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
        }


        public async Task<KhenThuongDto> Handle(GetKhenThuongByIdQuery request, CancellationToken cancellationToken)
        {
            var k = await _khenThuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Khen Thuong not found");
            }

            return k.MapToKhenThuongDto(_mapper);
        }
    }
}
