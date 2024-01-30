using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepHandler : IRequestHandler<UpdateLoaiNghiPhepCommand, LoaiNghiPhepDto>
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

        public async Task<LoaiNghiPhepDto> Handle(UpdateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAnyAsync(x => x.ID == request.Id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LoaiNghiPhep với id không tìm thấy");
            }
            if(lnp.NgayXoa != null)
            {
                throw new InvalidOperationException("Loại nghỉ phép này đã bị xóa rồi");
            }
            lnp.ID = request.Id;
            lnp.Name = request.Name ?? lnp.Name;
            _repository.Update(lnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LoaiNghiPhepDto>(lnp);
        }
    }
}