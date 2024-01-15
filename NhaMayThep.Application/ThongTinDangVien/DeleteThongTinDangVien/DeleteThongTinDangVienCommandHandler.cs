using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien
{
    public class DeleteThongTinDangVienCommandHandler : IRequestHandler<DeleteThongTinDangVienCommand, ThongTinDangVienDto>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;
        public DeleteThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinDangVienDto> Handle(DeleteThongTinDangVienCommand request, CancellationToken cancellationToken)
        {

            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.ID == request.ID);
            if (thongTinDangVien == null)
                throw new NotFoundException("Dang Vien is not found");

            thongTinDangVien.NguoiXoaID = request.NguoiXoaID; 
            thongTinDangVien.NgayXoa = DateTime.Now;

            _thongTinDangVienRepository.Update(thongTinDangVien);
            await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return thongTinDangVien.MapToThongTinDangVienDto(_mapper);
        }
    }
}
