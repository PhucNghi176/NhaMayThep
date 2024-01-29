using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdNguoiTao
{
    public class GetByIdNguoiTaoQueryHandler : IRequestHandler<GetByIdNguoiTaoQuery, List<HoaDonCongTacNhanVienDto>>
    {
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;

        public GetByIdNguoiTaoQueryHandler(IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository,
            IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<List<HoaDonCongTacNhanVienDto>> Handle(GetByIdNguoiTaoQuery request, CancellationToken cancellationToken)
        {
            var userExist = await _nhanVienRepository.FindAnyAsync(x => x.ID == request.idNguoiTao && !x.NgayXoa.HasValue,cancellationToken);
            if (userExist == null) 
            {
                throw new NotFoundException("Người dùng trên không hợp lệ");
            }
            var list = await _hoaDonCongTacNhanVienRepository.FindAllAsync(x => x.NguoiTaoID == request.idNguoiTao && !x.NgayXoa.HasValue, cancellationToken);
            if (!list.Any()) 
            {
                throw new NotFoundException("Danh Sách Rỗng");
            }
            return list.MapToHoaDonCongTacNhanVienDtoList(_mapper);
        }
    }
}
