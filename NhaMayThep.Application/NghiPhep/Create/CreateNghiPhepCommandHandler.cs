using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Create
{
    public class CreateNghiPhepCommandHandler : IRequestHandler<CreateNghiPhepCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly INghiPhepRepository _nghiPhepRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepository;

        public CreateNghiPhepCommandHandler(ICurrentUserService currentUserService, IMapper mapper, INghiPhepRepository nghiPhepRepository, INhanVienRepository nhanVienRepository, ILoaiNghiPhepRepository loaiNghiPhepRepository)
        {
            _mapper = mapper;
            _nghiPhepRepository = nghiPhepRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
            _loaiNghiPhepRepository = loaiNghiPhepRepository;
        }

        public async Task<string> Handle(CreateNghiPhepCommand request, CancellationToken cancellationToken)
        {


            var existingNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (!existingNhanVien)
            {
                return "Thất Bại! Nhân viên không tồn tại.";
            }

            var existingLoaiNghiPhep = await _loaiNghiPhepRepository.AnyAsync(x => x.ID == request.LoaiNghiPhepId && x.NgayXoa == null, cancellationToken);
            if (!existingLoaiNghiPhep)
            {
                return "Thất Bại! Loại nghỉ phép không hợp lệ.";
            }

            var nghiPhep = new NghiPhepEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                LuongNghiPhep = request.LuongNghiPhep,
                KhoanTruLuong = request.KhoanTruLuong,
                SoGioNghiPhep = request.SoGioNghiPhep,
                LoaiNghiPhepID = request.LoaiNghiPhepId,
                NguoiTaoID = _currentUserService.UserId
            };

            _nghiPhepRepository.Add(nghiPhep);

            return await _nghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Thành Công!" : "Thất Bại!";
        }
    }
}
