using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiHoaDon.GetAll
{
    public class GetAllLoaiHoaDonQueryHandler : IRequestHandler<GetAllLoaiHoaDonQuerry, List<LoaiHoaDonDto>>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public GetAllLoaiHoaDonQueryHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<List<LoaiHoaDonDto>> Handle(GetAllLoaiHoaDonQuerry request, CancellationToken cancellationToken)
        {
            var list = await _LoaiHoaDonRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("Danh Sách Rỗng");
            }
            return list.MapToLoaiHoaDonDtoList(_mapper);
        }

    }
}
