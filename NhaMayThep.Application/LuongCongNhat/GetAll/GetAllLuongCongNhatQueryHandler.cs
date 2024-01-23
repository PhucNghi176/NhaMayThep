using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LuongCongNhat.GetAll
{
    public class GetAllLuongCongNhatQueryHandler : IRequestHandler<GetAllLuongCongNhatQuery, List<LuongCongNhatDto>>
    {
        private readonly ILuongCongNhatRepository _LuongCongNhatRepository;
        private readonly IMapper _mapper;

        public GetAllLuongCongNhatQueryHandler(ILuongCongNhatRepository LuongCongNhatRepository, IMapper mapper)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _mapper = mapper;
        }

        public async Task<List<LuongCongNhatDto>> Handle(GetAllLuongCongNhatQuery request, CancellationToken cancellationToken)
        {

            var LuongCongNhatList = await _LuongCongNhatRepository.FindAllAsync(cancellationToken);
            return LuongCongNhatList.MapToLuongCongNhatDtoList(_mapper);
        }
    }
}
