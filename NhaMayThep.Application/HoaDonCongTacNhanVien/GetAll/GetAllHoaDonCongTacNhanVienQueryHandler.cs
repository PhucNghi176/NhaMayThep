using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetAll
{
    public class GetAllHoaDonCongTacNhanVienQueryHandler : IRequestHandler<GetAllHoaDonCongTacNhanVienQuery, List<HoaDonCongTacNhanVienDto>>
    {
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public GetAllHoaDonCongTacNhanVienQueryHandler(IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository, IMapper mapper)
        {
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<List<HoaDonCongTacNhanVienDto>> Handle(GetAllHoaDonCongTacNhanVienQuery request, CancellationToken cancellationToken)
        {
            var list = await _hoaDonCongTacNhanVienRepository.FindAllAsync(x => !x.NgayXoa.HasValue,cancellationToken);
            if(list == null) 
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToHoaDonCongTacNhanVienDtoList(_mapper);
        }
    }
}
