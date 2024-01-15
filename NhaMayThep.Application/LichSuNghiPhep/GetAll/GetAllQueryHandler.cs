using MediatR;
using NhaMayThep.Application.LoaiNghiPhep.GetAll;
using NhaMayThep.Application.LoaiNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;
using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllLSNPQuery, List<LichSuNghiPhepDto>>
    {
        private readonly ILichSuNghiPhepRepo _repository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(ILichSuNghiPhepRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }



        public async Task<List<LichSuNghiPhepDto>> Handle(GetAllLSNPQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync();
            if(lsnp == null)
            {
                throw new NotFoundException("The list is empty");
            }

            return lsnp.MapToLichSuNghiPhepDtoList(_mapper);
        }
    }
}
