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

        public UpdateLoaiNghiPhepHandler(ILoaiNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoaiNghiPhepDto> Handle(UpdateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindByIdAsync(request.Id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LoaiNghiPhep not found for the given ID");
            }
            lnp.ID = request.Id;
            lnp.Name = request.Name ?? lnp.Name;
            lnp.SoGioNghiPhep = request.SoGioNghiPhep;

            _repository.Update(lnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LoaiNghiPhepDto>(lnp);
        }
    }
}
