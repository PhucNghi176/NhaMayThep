using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll
{
    public class GetAllChiTietNghiPhepQueryHandler : IRequestHandler<GetAllChiTietNghiPhepQuery,List<ChiTietNgayNghiPhepDto>>
    {
        private readonly IChiTietNgayNghiPhepRepo _repo;
        private readonly IMapper _mapper;
        public GetAllChiTietNghiPhepQueryHandler(IChiTietNgayNghiPhepRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ChiTietNgayNghiPhepDto>> Handle(GetAllChiTietNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var ctnp = await _repo.FindAllAsync();
            if (ctnp == null)
            {
                throw new NotFoundException("The list is empty");
            }
            return ctnp.MapToChiTietNgayNghiPhepDtoList(_mapper);
        }
    }
}
