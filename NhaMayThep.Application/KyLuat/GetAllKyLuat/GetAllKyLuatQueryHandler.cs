using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetAllKyLuat
{
    public class GetAllKyLuatQueryHandler : IRequestHandler<GetAllKyLuatQuery, List<KyLuatDTO>>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        public GetAllKyLuatQueryHandler(IKyLuatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetAllKyLuatQueryHandler() { }
        public async Task<List<KyLuatDTO>> Handle(GetAllKyLuatQuery request, CancellationToken cancellationToken)
        {
            var kyluat = await this._repository.FindAllAsync(x => x.NgayXoa == null,cancellationToken);
            if(kyluat.Count() == 0) 
                throw new NotFoundException("Không tìm thấy trường hợp kỷ luật nào.");
            return kyluat.MapToTinhKyLuatDTOList(_mapper).ToList();
        }
    }
}
