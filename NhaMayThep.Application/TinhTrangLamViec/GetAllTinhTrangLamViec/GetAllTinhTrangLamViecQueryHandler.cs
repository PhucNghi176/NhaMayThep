using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec
{
    public class GetAllTinhTrangLamViecQueryHandler : IRequestHandler<GetAllTinhTrangLamViecQuery, List<TinhTrangLamViecDTO>>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        public GetAllTinhTrangLamViecQueryHandler(ITinhTrangLamViecRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TinhTrangLamViecDTO>> Handle(GetAllTinhTrangLamViecQuery request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.FindAllAsync(X => X.NgayXoa == null,cancellationToken);
            if (tinhtranglamviec == null)
                throw new Exception("Not found any tình trạng làm việc");
            
            return tinhtranglamviec.MapToTinhTrangLamViecDTOList(_mapper).ToList();
        }
    }
}
