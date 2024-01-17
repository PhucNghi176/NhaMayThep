using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.KhenThuong.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetAll
{
    public class GetAllKhenThuongQueryHandler : IRequestHandler<GetAllKhenThuongQuery, List<KhenThuongDto>>
    {
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;

        public GetAllKhenThuongQueryHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper)
        {
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
        }


        public async Task<List<KhenThuongDto>> Handle(GetAllKhenThuongQuery request, CancellationToken cancellationToken)
        {
            var ks = await _khenThuongRepository.FindAllAsync(cancellationToken);

            if (ks == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var ksReturn = ks.Where(x => x.NgayXoa == null).ToList();

            return ksReturn.MapToKhenThuongDtoList(_mapper);
        }
    }
}
