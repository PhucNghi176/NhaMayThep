using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.DeleteChiTietDangVien
{
    public class DeleteChiTietDangVienCommandHandler : IRequestHandler<DeleteChiTietDangVienCommand, string>
    {
        private IChiTietDangVienRepository _chiTietDangVienRepository;
        private readonly IMapper _mapper;
        public DeleteChiTietDangVienCommandHandler(IChiTietDangVienRepository chiTietDangVienRepository, IMapper mapper)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(DeleteChiTietDangVienCommand request, CancellationToken cancellationToken)
        {
            var chiTietDangVien = await _chiTietDangVienRepository.FindAsync(x => x.ID == request.ID, cancellationToken: cancellationToken);
            if (chiTietDangVien == null)
                throw new NotFoundException("Chi Tiet Dang Vien is not found");

            chiTietDangVien.NguoiXoaID = request.NguoiXoaID;
            chiTietDangVien.NgayXoa = DateTime.Now;

            _chiTietDangVienRepository.Update(chiTietDangVien);
            await _chiTietDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Delete Successfully";
        }
    }
}
