using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommandHandler : IRequestHandler<DeleteThongTinLuongNhanVienCommand, ThongTinLuongNhanVienDto>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public DeleteThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(DeleteThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
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

            var t = k.FirstOrDefault(x => x.MaSoNhanVien ==  request.MaSoNhanVien);

            _thongTinLuongNhanVienRepository.Remove(t);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return t.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
