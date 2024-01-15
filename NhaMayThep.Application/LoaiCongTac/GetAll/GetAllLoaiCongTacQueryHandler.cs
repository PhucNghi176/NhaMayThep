using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.GetAll
{
    public class GetAllLoaiCongTacQueryHandler : IRequestHandler<GetAllLoaiCongTacQuery, List<LoaiCongTacDto>>
    {
        public readonly ILoaiCongTacRepository _LoaiCongTacRepository;
        public readonly IMapper _mapper;

        public GetAllLoaiCongTacQueryHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _LoaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<List<LoaiCongTacDto>> Handle(GetAllLoaiCongTacQuery request, CancellationToken cancellationToken)
        {
                var list = await _LoaiCongTacRepository.FindAllAsync(cancellationToken);
                if(list == null)
                {
                throw new NotFoundException("LoaiCongTac list is empty");
                }
            return list.MapToLoaiCongTacDtoList(_mapper);
        }
    }
}
