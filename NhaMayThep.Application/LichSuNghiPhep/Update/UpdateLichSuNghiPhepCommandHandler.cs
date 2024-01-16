using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMayThep.Application.LichSuNghiPhep;

public class UpdateLichSuNghiPhepCommandHandler : IRequestHandler<UpdateLichSuNghiPhepCommand, LichSuNghiPhepDto>
{
    private readonly ILichSuNghiPhepRepository _repo;
    private readonly IMapper _mapper;
    private readonly INhanVienRepository _nhanVienRepository;

    public UpdateLichSuNghiPhepCommandHandler(ILichSuNghiPhepRepository repo, IMapper mapper, INhanVienRepository nhanVienRepository)
    {
        _repo = repo;
        _mapper = mapper;
        _nhanVienRepository = nhanVienRepository;
    }

    public async Task<LichSuNghiPhepDto> Handle(UpdateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var existingNhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
        if (existingNhanVien == null)
        {
            throw new NotFoundException($"Employee with ID {request.MaSoNhanVien} not found.");
        }

        var existingNhanVien2 = await _nhanVienRepository.FindAsync(x => x.ID == request.NguoiDuyet, cancellationToken);
        if(existingNhanVien2 == null)
        {
            throw new NotFoundException($"Nguoi Duyet with ID {request.NguoiDuyet} not found.");
        }

        var existingLsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
        if (existingLsnp == null)
        {
            throw new NotFoundException($"LichSuNghiPhepNhanVienEntity with ID {request.Id} not found.");
        }

        // Update the properties of existingLsnp
        existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
        existingLsnp.NgayBatDau = request.NgayBatDau;
        existingLsnp.NgayKetThuc = request.NgayKetThuc;
        existingLsnp.LyDo = request.LyDo;
        existingLsnp.NguoiDuyet = request.NguoiDuyet;

        _repo.Update(existingLsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LichSuNghiPhepDto>(existingLsnp);
    }
}
