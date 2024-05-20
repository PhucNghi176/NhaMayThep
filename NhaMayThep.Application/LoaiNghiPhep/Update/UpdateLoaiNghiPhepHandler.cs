using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepHandler : IRequestHandler<UpdateLoaiNghiPhepCommand, string>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _hanVienRepository;
        public UpdateLoaiNghiPhepHandler(ILoaiNghiPhepRepository repository, IMapper mapper, INhanVienRepository hanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _hanVienRepository = hanVienRepository;
        }

        public async Task<string> Handle(UpdateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LoaiNghiPhep với ID không tìm thấy.");
            }

            if (lnp.NgayXoa != null)
            {
                throw new NotFoundException("LoaiNghiPhep này đã bị xóa.");
            }

            // Check if another LoaiNghiPhep with the same name (but a different ID) exists
            var existingWithName = await _repository.FindAllAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.ID != request.Id && x.NgayXoa == null, cancellationToken);
            if (existingWithName.Any())
            {
                // If such an entity exists, throw a duplication exception or return a message indicating the name is already taken.
                throw new DuplicationException($"Loại Nghỉ Phép với tên này  '{request.Name}' đã có sẵn.");
            }

            // Proceed with updating the LoaiNghiPhep if no duplicates are found
            lnp.Name = request.Name ?? lnp.Name;
            _repository.Update(lnp);

            if (await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Update thành công.";
            else
                return "Update thất bại.";
        }
    }
}