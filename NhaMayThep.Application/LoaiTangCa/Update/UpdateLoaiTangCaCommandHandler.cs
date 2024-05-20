using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaHandler : IRequestHandler<UpdateLoaiTangCaCommand, string>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ILoaiTangCaRepository _loaiTangCaRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLoaiTangCaHandler(ILoaiTangCaRepository repository, IMapper mapper, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService, ILoaiTangCaRepository loaiTangCaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _hanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
            _loaiTangCaRepository = loaiTangCaRepository;
        }

        public async Task<string> Handle(UpdateLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var loaiTangCa = await _repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (loaiTangCa == null)
            {
                return $"Không tìm thấy trường hợp Loại Tăng Ca với ID : {request.Id} hoặc trường hợp này đã bị xóa.";
            }

            var name = await this._loaiTangCaRepository.FindAsync(x => x.Name.Equals(request.Name) && x.ID != request.Id && x.NgayXoa == null, cancellationToken);
            if (name != null)
                throw new NotFoundException($"Name đã tồn tại");

            loaiTangCa.NguoiCapNhatID = this._currentUserService.UserId;
            loaiTangCa.NgayCapNhat = DateTime.UtcNow;
            loaiTangCa.Name = request.Name;
            _repository.Update(loaiTangCa);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Loại Tăng Ca thành công" : "Cập nhật Loại Tăng Ca thất bại";
        }
    }
}
