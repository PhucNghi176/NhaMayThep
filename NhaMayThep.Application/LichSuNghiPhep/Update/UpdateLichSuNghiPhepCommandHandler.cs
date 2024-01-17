using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.Common.Interfaces;

public class UpdateLichSuNghiPhepCommandHandler : IRequestHandler<UpdateLichSuNghiPhepCommand, LichSuNghiPhepDto>
{
    private readonly ILichSuNghiPhepRepository _repo;
    private readonly IMapper _mapper;
    private readonly INhanVienRepository _nhanVienRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;
    public UpdateLichSuNghiPhepCommandHandler(ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepository, ILichSuNghiPhepRepository repo, IMapper mapper, INhanVienRepository nhanVienRepository)
    {
        _repo = repo;
        _mapper = mapper;
        _nhanVienRepository = nhanVienRepository;
        _currentUserService = currentUserService;
        _loaiNghiPhepRepo = loaiNghiPhepRepository;
    }

    public async Task<LichSuNghiPhepDto> Handle(UpdateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("User ID not found.");
        }
        var loaiNghiPhepExists = await _loaiNghiPhepRepo.AnyAsync(x => x.ID == request.LoaiNghiPhepID, cancellationToken);
        if (!loaiNghiPhepExists)
        {
            throw new NotFoundException("LoaiNghiPhepId provided does not exist.");
        }
        var existingNhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
        if (existingNhanVien == null)
        {
            throw new NotFoundException($"Employee with ID {request.MaSoNhanVien} not found.");
        }
        if(existingNhanVien.NgayXoa != null)
        {
            throw new InvalidOperationException("This NhanVien has been deleted");
        }

        var existingNhanVien2 = await _nhanVienRepository.FindAsync(x => x.ID == request.NguoiDuyet, cancellationToken);
        if(existingNhanVien2 == null)
        {
            throw new NotFoundException($"Nguoi Duyet with ID {request.NguoiDuyet} not found.");
        }

        if(existingNhanVien2.NgayXoa != null)
        {
            throw new InvalidOperationException("This NhanVien has been deleted");
        }

        var existingLsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
        if (existingLsnp == null)
        {
            throw new NotFoundException($"LichSuNghiPhepNhanVienEntity with ID {request.Id} not found.");
        }
        if(existingLsnp.NgayXoa != null)
        {
            throw new InvalidOperationException("This LichSuNghiPhep has been deleted");
        }



        // Update the properties of existingLsnp
        existingLsnp.NguoiCapNhatID = userId;
        existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
        existingLsnp.NgayBatDau = request.NgayBatDau;
        existingLsnp.NgayKetThuc = request.NgayKetThuc;
        existingLsnp.LyDo = request.LyDo;
        existingLsnp.NguoiDuyet = request.NguoiDuyet;
        existingLsnp.NgayCapNhatCuoi = DateTime.Now;
        _repo.Update(existingLsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LichSuNghiPhepDto>(existingLsnp);
    }
}
