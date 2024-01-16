using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLnpByIdHandler : IRequestHandler<GetLnpByIdQuery,LoaiNghiPhepDto>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        
        public GetLnpByIdHandler(ILoaiNghiPhepRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LoaiNghiPhepDto> Handle(GetLnpByIdQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindByIdAsync(request.id, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LNP Does not Exist");

            }
            return lnp.MapToLoaiNghiPhepDto(_mapper);
        }
    }
}
