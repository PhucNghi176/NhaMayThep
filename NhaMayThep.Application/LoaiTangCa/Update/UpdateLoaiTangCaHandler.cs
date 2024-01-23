using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiTangCa.Update;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaHandler : IRequestHandler<UpdateLoaiTangCaCommand, LoaiTangCaDto>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public UpdateLoaiTangCaHandler(ILoaiTangCaRepository repository, IMapper mapper, INhanVienRepository hanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = hanVienRepository;
        }

        public async Task<LoaiTangCaDto> Handle(UpdateLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LoaiTangCa not found for the given ID");
            }
            if (lnp.NgayXoa != null)
            {
                throw new InvalidOperationException("This LoaiTangCa has been deleted");
            }
            lnp.ID = request.Id;
            lnp.Name = request.Name ?? lnp.Name;
            _repository.Update(lnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LoaiTangCaDto>(lnp);
        }
    }
}
