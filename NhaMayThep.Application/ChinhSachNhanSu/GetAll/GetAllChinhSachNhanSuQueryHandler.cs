using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChinhSachNhanSu.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetAll
{
    public class GetAllChinhSachNhanSuQueryHandler : IRequestHandler<GetAllChinhSachNhanSuQuery, List<ChinhSachNhanSuDto>>
    {
        private readonly IChinhSachNhanSuRepository _chinhSuRepository;
        private readonly IMapper _mapper;

        public GetAllChinhSachNhanSuQueryHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }


        public async Task<List<ChinhSachNhanSuDto>> Handle(GetAllChinhSachNhanSuQuery request, CancellationToken cancellationToken)
        {
            var chinhsachs = await _chinhSuRepository.FindAllAsync(cancellationToken);

            if (chinhsachs == null )
            {
                throw new NotFoundException("List is empty");
            }

            var chinhsachsReturn = chinhsachs.Where(x => x.NgayXoa == null).ToList();
            return chinhsachsReturn.MapToChinhSachNhanSuDtoList(_mapper);
        }
    }
}
