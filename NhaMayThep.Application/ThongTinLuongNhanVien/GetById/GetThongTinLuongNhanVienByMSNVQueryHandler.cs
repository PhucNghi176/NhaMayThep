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
            var nhanvien = await _nhanVienRepository.FindByIdAsync(request.MaSoNhanVien.ToString(), cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }

            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var t = k.FirstOrDefault(x => x.MaSoNhanVien == request.MaSoNhanVien);

            if (t == null)
            {
                throw new NotFoundException("Thong Tin Luong with MSNV is not exist");
            }
            return t.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
