using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommandHandler : IRequestHandler<DeleteThongTinLuongNhanVienCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;

        public DeleteThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
        }


        public async Task<string> Handle(DeleteThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var thongtin = await _thongTinLuongNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);

            if (thongtin is null || thongtin.NgayXoa.HasValue)
            {
                throw new NotFoundException("Thông Tin Không Tìm Thấy Hoặc Đã Bị Xóa");
            }

            thongtin.NguoiXoaID = _currentUserService.UserId;
            thongtin.NgayXoa = DateTime.Now;

            _thongTinLuongNhanVienRepository.Update(thongtin);
            return await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Thành Công" : "Xóa Thất Bại";
        }
    }
}
