using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.GetByNhanVienIDThongTinDangVien
{
    public class GetByNhanVienIDThongTinDangVienCommandHandler : IRequestHandler<GetByNhanVienIDThongTinDangVienCommand, List<ThongTinDangVienDto>>
    {
        private readonly IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;

        public GetByNhanVienIDThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinDangVienDto>> Handle(GetByNhanVienIDThongTinDangVienCommand request, CancellationToken cancellationToken)
        {

            var thongTinDangVien = await _thongTinDangVienRepository.FindAllAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken);
            if(thongTinDangVien == null)
                throw new NotFoundException("Không tìm thấy Thông Tin Đảng Viên");

            return thongTinDangVien.MapToThongTinDangVienDtoList(_mapper);
        }
    }
}
