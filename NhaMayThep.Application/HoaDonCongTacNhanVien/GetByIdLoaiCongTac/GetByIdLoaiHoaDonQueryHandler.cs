using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiCongTac
{
    public class GetByIdLoaiHoaDonQueryHandler : IRequestHandler<GetByIdLoaiHoaDonQuery, List<HoaDonCongTacNhanVienDto>>
    {
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ILoaiHoaDonRepository _loaiHoaDonRepository;

        public GetByIdLoaiHoaDonQueryHandler(IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository,
            IMapper mapper, ILoaiHoaDonRepository loaiHoaDonRepository)
        {
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _mapper = mapper;
            _loaiHoaDonRepository = loaiHoaDonRepository;
        }

        public async Task<List<HoaDonCongTacNhanVienDto>> Handle(GetByIdLoaiHoaDonQuery request, CancellationToken cancellationToken)
        {
            var list = await _hoaDonCongTacNhanVienRepository.FindAllAsync(x =>
             x.LoaiHoaDonID == request.idLoaiHoaDon &&
            !x.NgayXoa.HasValue &&
             x.DuongDanFile.Contains($"/{request.year}/{request.month}/"),
             cancellationToken);

            var loaiHoaDon = await _loaiHoaDonRepository.FindAsync(x => x.ID == request.idLoaiHoaDon,cancellationToken);
            if(loaiHoaDon == null) 
            {
                throw new NotFoundException("Loại Công Tác Trên không Tồn Tại");
            }
            if(list == null || !list.Any())
            {
                throw new NotFoundException($"Không Tìm Thấy Tệp tin nào Tại Loại Hóa Đon :{loaiHoaDon.Name} vào năm :{request.year}, tháng : {request.month} ");
            }
            return list.MapToHoaDonCongTacNhanVienDtoList(_mapper);
        }
    }
}
