using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllLichSuNghiPhepQueryHandler : IRequestHandler<GetAllLichSuNghiPhepQuery, List<LichSuNghiPhepDto>>
    {
        private readonly ILichSuNghiPhepRepository _repository;
        private readonly IMapper _mapper;


        public GetAllLichSuNghiPhepQueryHandler(ILichSuNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<LichSuNghiPhepDto>> Handle(GetAllLichSuNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync();
            if (lsnp == null)
            {
                throw new NotFoundException("The list is empty");
            }

            return lsnp.MapToLichSuNghiPhepDtoList(_mapper);
        }
    }
}
