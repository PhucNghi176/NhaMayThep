using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommandHandler : IRequestHandler<CreateChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IMapper _mapper;
        private readonly IChiTietNgayNghiPhepRepository _repository;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;
        public CreateChiTietNgayNghiPhepCommandHandler(IMapper mapper, IChiTietNgayNghiPhepRepository repository, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _hanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
            _loaiNghiPhepRepo = loaiNghiPhepRepo;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(CreateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Nhan Vien does not exist.");
            }
            if (nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Cannot create ChiTietNgayNghiPhep as the NhanVien has been marked as deleted.");
            }
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId provided does not exist.");
            }
            var ctnp = new ChiTietNgayNghiPhepEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                TongSoGio = request.TongSoGio,
                SoGioDaNghiPhep = request.SoGioDaNghiPhep,
                SoGioConLai = request.SoGioConLai,
                NamHieuLuc = request.NamHieuLuc
            };

            _repository.Add(ctnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ctnp.MapToChiTietNgayNghiPhepDto(_mapper);
        }
    }
}
