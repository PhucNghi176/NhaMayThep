using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LoaiTangCaDto>>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILoaiTangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LoaiTangCaDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var LoaiTangCa = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (LoaiTangCa == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Loại Tăng Ca nào.");
            return LoaiTangCa.MapToLoaiTangCaDtoList(_mapper).ToList();
        }
    }
}