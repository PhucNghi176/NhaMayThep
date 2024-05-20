using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

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
                throw new UnauthorizedAccessException("User ID không tìm thấy.");
            }
            var existingLsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (existingLsnp == null)
            {
                throw new NotFoundException($"ChiTietNghiPhep với Id {request.Id} không tìm thấy.");
            }
            if (existingLsnp.NgayXoa != null)
            {
                throw new NotFoundException("This ID đã bị xóa");
            }
            var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
            if (!loaiNghiPhepExists)
            {
                throw new NotFoundException("LoaiNghiPhepId không tồn tại.");
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
