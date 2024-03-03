using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.NghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.GetAll
{
    public class GetAllNghiPhepHandler : IRequestHandler<GetAllNghiPhepQuery, List<NghiPhepDto>>
    {
        private readonly INghiPhepRepository _repository;
        private readonly IMapper _mapper;
        public GetAllNghiPhepHandler(INghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<NghiPhepDto>> Handle(GetAllNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var NghiPhep = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (NghiPhep == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Nghỉ Phép nào.");
            return NghiPhep.MapToNghiPhepDtoList(_mapper).ToList();

        }
    }
}
