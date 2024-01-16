using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChinhSachNhanSu.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanSuByIdQueryHandler : IRequestHandler<GetChinhSachNhanSuByIdQuery, ChinhSachNhanSuDto>
    {
        private readonly IChinhSachNhanSuRepository _chinhSuRepository;
        private readonly IMapper _mapper;

        public GetChinhSachNhanSuByIdQueryHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }


        public async Task<ChinhSachNhanSuDto> Handle(GetChinhSachNhanSuByIdQuery request, CancellationToken cancellationToken)
        {
            var chinhsach = await _chinhSuRepository.FindByIdAsync(request.Id, cancellationToken);

            if (chinhsach == null || chinhsach.NgayXoa != null)
            {
                throw new NotFoundException("Chinh sach is not found");
            }
            return chinhsach.MapToChinhSachNhanSuDto(_mapper);
        }
    }
}
