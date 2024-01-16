using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
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

            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }
            var thongtin = await _thongTinLuongNhanVienRepository.FindByIdAsync(request.Id, cancellationToken);

            if (thongtin == null)
            {
                throw new NotFoundException("Thong tin not found");
            }

            if (thongtin.NgayXoa != null)
            {
                throw new NotFoundException("Thong tin is deleted");
            }

            thongtin.NgayXoa = DateTime.Now;

            _thongTinLuongNhanVienRepository.Update(thongtin);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return thongtin.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
