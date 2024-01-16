using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByMSNVQueryHandler : IRequestHandler<GetThongTinLuongNhanVienByMSNVQuery, ThongTinLuongNhanVienDto>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public GetThongTinLuongNhanVienByMSNVQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(GetThongTinLuongNhanVienByMSNVQuery request, CancellationToken cancellationToken)
        {
            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var thongtin = await _thongTinLuongNhanVienRepository.FindByIdAsync(request.Id.ToString(), cancellationToken);

            if (thongtin == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }

            if (thongtin.NgayXoa != null)
            {
                throw new NotFoundException("Thong Tin Luong is deleted");
            }
            return thongtin.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
