using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.Common.Interfaces;

public class DeleteLichSuNghiPhepCommandHandler : IRequestHandler<DeleteLichSuNghiPhepCommand, LichSuNghiPhepDto>
{
    private readonly ILichSuNghiPhepRepository _repo;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    public DeleteLichSuNghiPhepCommandHandler(ILichSuNghiPhepRepository repo, IMapper mapper, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<LichSuNghiPhepDto> Handle(DeleteLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("User ID not found.");
        }
        var lsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
        if (lsnp == null)
        {
            throw new NotFoundException($"LichSuNghiPhep with ID {request.Id} not found.");
        }
        if(lsnp.NgayXoa != null)
        {
            throw new NotFoundException("This LichSuNghiPhep has been deleted");
        }

        lsnp.NguoiXoaID = userId;
        lsnp.NgayXoa = DateTime.Now;

        _repo.Update(lsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LichSuNghiPhepDto>(lsnp);
    }
}
