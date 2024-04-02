using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetAll
{
    public class GetAllThongTinLuongNhanVienQueryHandler : IRequestHandler<GetAllThongTinLuongNhanVienQuery, List<ThongTinLuongNhanVienDTO>>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinLuongNhanVienQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _mapper = mapper;
        }


        public async Task<List<ThongTinLuongNhanVienDTO>> Handle(GetAllThongTinLuongNhanVienQuery request, CancellationToken cancellationToken)
        {

            var list = await _thongTinLuongNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToThongTinLuongNhanVienDtoList(_mapper);
        }
    }
}
