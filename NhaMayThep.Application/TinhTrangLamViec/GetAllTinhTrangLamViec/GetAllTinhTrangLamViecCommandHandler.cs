using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec
{
    public class GetAllTinhTrangLamViecCommandHandler : IRequestHandler<GetAllTinhTrangLamViecCommand, List<TinhTrangLamViecDTO>>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly IMapper _mapper;
        public GetAllTinhTrangLamViecCommandHandler(ITinhTrangLamViec repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TinhTrangLamViecDTO>> Handle(GetAllTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.FindAllAsync(cancellationToken);
            if (tinhtranglamviec == null)
                throw new Exception("Not found any tình trạng làm việc");
            foreach(var items in tinhtranglamviec)
            {
                if (items.NgayXoa != null)
                    tinhtranglamviec.Remove(items);
            }
            return tinhtranglamviec.MapToTinhTrangLamViecDTOList(_mapper);
        }
    }
}
