using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LuongThoiGian.GetAll
{
    public class GetAllLuongThoiGianQueryHandler : IRequestHandler<GetAllLuongThoiGianQuery, List<LuongThoiGianDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILuongThoiGianRepository _luongThoiGianRepository;

        public GetAllLuongThoiGianQueryHandler(IMapper mapper, ILuongThoiGianRepository luongThoiGianRepository)
        {
            _mapper = mapper;
            _luongThoiGianRepository = luongThoiGianRepository;
        }
        public async Task<List<LuongThoiGianDto>> Handle(GetAllLuongThoiGianQuery request, CancellationToken cancellationToken)
        {
            var luongThoiGianList = await _luongThoiGianRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (luongThoiGianList == null || !luongThoiGianList.Any())
            {
                throw new NotFoundException("Không có lương thời gian nào!");
            }
            return luongThoiGianList.MapToLuongThoiGianDtoList(_mapper);
        }
    }
}
