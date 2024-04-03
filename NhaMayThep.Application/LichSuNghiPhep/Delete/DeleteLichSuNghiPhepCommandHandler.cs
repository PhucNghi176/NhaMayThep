using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
namespace NhaMayThep.Application.LichSuNghiPhep.Delete;
public class DeleteLichSuNghiPhepCommandHandler : IRequestHandler<DeleteLichSuNghiPhepCommand, string>
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

    public async Task<string> Handle(DeleteLichSuNghiPhepCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("User ID không tồn tại .");
        }
        var lsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
        if (lsnp == null)
        {
            throw new NotFoundException($"LichSuNghiPhep với Id  {request.Id} không tìm thấy .");
        }
        if(lsnp.NgayXoa != null)
        {
            return "LichSuNghiPhep này đã bị xóa trước đó.";
        }

        lsnp.NguoiXoaID = userId;
        lsnp.NgayXoa = DateTime.Now;


        _repo.Update(lsnp);
        await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return "Xóa lịch sử nghỉ phép thành công.";


    }
}
