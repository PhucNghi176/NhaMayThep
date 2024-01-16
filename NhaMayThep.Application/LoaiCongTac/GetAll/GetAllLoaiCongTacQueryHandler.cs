using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.GetAll
{
    public class GetAllLoaiCongTacQueryHandler : IRequestHandler<GetAllLoaiCongTacQuery, List<LoaiCongTacDto>>
    {
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;
        private readonly IMapper _mapper;

        public GetAllLoaiCongTacQueryHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<List<LoaiCongTacDto>> Handle(GetAllLoaiCongTacQuery request, CancellationToken cancellationToken)
        {
            var list = await _loaiCongTacRepository.FindAllAsync(x => x.NgayXoa == null,cancellationToken);
            if(list is null) 
            {
                throw new NotFoundException("this list is empty");
            }
            return list.MapToLoaiCongTacDtoList(_mapper);
        }
    }
}
