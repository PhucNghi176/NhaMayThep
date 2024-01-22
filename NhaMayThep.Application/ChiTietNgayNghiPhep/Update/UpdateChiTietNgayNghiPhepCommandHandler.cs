using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNgayNghiPhepCommandHandler : IRequestHandler<UpdateChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;
        public UpdateChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepository repo, IMapper mapper, ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUserService = currentUserService;
           _loaiNghiPhepRepo = loaiNghiPhepRepo;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(UpdateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }
            var existingLsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (existingLsnp == null)
            {
                throw new NotFoundException($"ChiTietNghiPhep with Id {request.Id} not found.");
            }
            if (existingLsnp.NgayXoa != null)
            {
                throw new NotFoundException("This ID is deleted");
            }
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId provided does not exist.");
            }

            // Update properties
            existingLsnp.NguoiCapNhatID = userId;
            existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
            existingLsnp.TongSoGio = request.TongSoGio;
            existingLsnp.SoGioDaNghiPhep = request.SoGioDaNghiPhep;
            existingLsnp.SoGioConLai = request.SoGioConLai;
            existingLsnp.NamHieuLuc = request.NamHieuLuc;
            existingLsnp.NgayCapNhatCuoi = DateTime.Now;
            
            _repo.Update(existingLsnp);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChiTietNgayNghiPhepDto>(existingLsnp);
        }

    }
}
