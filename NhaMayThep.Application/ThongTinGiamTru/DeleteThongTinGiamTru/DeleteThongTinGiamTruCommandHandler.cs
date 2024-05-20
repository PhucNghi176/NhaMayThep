using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommandHandler : IRequestHandler<DeleteThongTinGiamTruCommand, string>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currenuserservice;
        public DeleteThongTinGiamTruCommandHandler(IThongTinGiamTruRepository repository, IMapper mapper, ICurrentUserService currenuserservice)
        {
            _currenuserservice = currenuserservice;
            _repository = repository;
            _mapper = mapper;
        }
        public DeleteThongTinGiamTruCommandHandler() { }
        public async Task<string> Handle(DeleteThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongtingiamtru == null || thongtingiamtru.NgayXoa != null)
                return $"Không tìm thấy thông tim giảm trừ với ID : {request.Id} hoặc thông tim giảm trừ này đã bị xóa.";
            thongtingiamtru.NguoiXoaID = _currenuserservice.UserId;
            thongtingiamtru.NgayXoa = DateTime.UtcNow;
            _repository.Update(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return $"Xóa thành công thông tim giảm trừ với ID : {request.Id}";
        }
    }
}
