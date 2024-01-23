using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiTangCa.GetById;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetById
{
    public class GetLoaiTangCaByIdQueryHandler : IRequestHandler<GetLoaiTangCaByIdQuery, LoaiTangCaDto>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;


        public GetLoaiTangCaByIdQueryHandler(ILoaiTangCaRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LoaiTangCaDto> Handle(GetLoaiTangCaByIdQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAsync(x => x.ID == request.id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LoaiTangCa Does not Exist");

            }
            if (lnp.NgayXoa != null)
            {
                throw new NotFoundException("LoaiTangCa Is Deleted");
            }

            return lnp.MapToLoaiTangCaDto(_mapper);
        }

    }
}
