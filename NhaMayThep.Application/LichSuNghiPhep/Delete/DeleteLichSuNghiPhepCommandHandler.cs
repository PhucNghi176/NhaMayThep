using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep;

public class DeleteLichSuNghiPhepCommandHandler : IRequestHandler<DeleteLichSuNghiPhepCommand, LichSuNghiPhepDto>
{
    private readonly ILichSuNghiPhepRepository _repo;
    private readonly IMapper _mapper;

    public DeleteLichSuNghiPhepCommandHandler(ILichSuNghiPhepRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<LichSuNghiPhepDto> Handle(DeleteLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var lsnp = await _repo.FindByIdAsync(request.Id, cancellationToken);
        if (lsnp == null)
        {
            throw new NotFoundException($"LichSuNghiPhep with ID {request.Id} not found.");
        }

        lsnp.NguoiXoaID = request.NguoiXoaID;
        lsnp.NgayXoa = DateTime.Now;

        _repo.Update(lsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LichSuNghiPhepDto>(lsnp);
    }
}
