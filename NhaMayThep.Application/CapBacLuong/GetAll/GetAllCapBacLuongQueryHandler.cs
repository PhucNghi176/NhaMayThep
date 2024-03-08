using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.GetAll
{
    public class GetAllCapBacLuongQueryHandler : IRequestHandler<GetAllCapBacLuongQuery, List<CapBacLuongDto>>
    {
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        private readonly IMapper _mapper;
        public GetAllCapBacLuongQueryHandler(ICapBacLuongRepository capBacLuongRepository, IMapper mapper)
        {
            _capBacLuongRepository = capBacLuongRepository;
            _mapper = mapper;
        }
        public async Task<List<CapBacLuongDto>> Handle(GetAllCapBacLuongQuery query, CancellationToken cancellationToken)
        {
            var capBacLuongList = await _capBacLuongRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (capBacLuongList == null || !capBacLuongList.Any())
            {
                throw new NotFoundException("Không có cấp bậc lương nào!");
            }
            return capBacLuongList.MapToCapBacLuongDtoList(_mapper);
        }
    }
}
