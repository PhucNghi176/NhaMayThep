using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDCommandHandler : IRequestHandler<GetTinhTrangLamViecByIDCommand, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly IMapper _mapper;
        public GetTinhTrangLamViecByIDCommandHandler(ITinhTrangLamViec repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TinhTrangLamViecDTO> Handle(GetTinhTrangLamViecByIDCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.GetTinhTrangLamViecById(request.id, cancellationToken);
            if (tinhtranglamviec == null)
                throw new ArgumentException($"Tình trạng làm việc với ID : {request.id} không tồn tại.");
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
