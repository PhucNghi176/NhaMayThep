using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetAll
{
    public class GetAllChinhSachNhanSuQueryHandler : IRequestHandler<GetAllChinhSachNhanSuQuery, List<ChinhSachNhanSuDto>>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly IMapper _mapper;
        public GetAllChinhSachNhanSuQueryHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }

        public async Task<List<ChinhSachNhanSuDto>> Handle(GetAllChinhSachNhanSuQuery query, CancellationToken cancellationToken)
        {
            var response = await _chinhSachNhanSuRepository.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (response == null)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ ChinhSachNhanSu nào");
            }
            return response.MapToChinhSachNhanSuDtoList(_mapper);
        }
    }
}
