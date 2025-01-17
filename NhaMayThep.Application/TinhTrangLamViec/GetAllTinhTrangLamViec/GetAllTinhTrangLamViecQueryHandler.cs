﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

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
            var tinhtranglamviec = await _repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (tinhtranglamviec == null)
                throw new NotFoundException("Không tìm thấy tình trạng làm việc.");

            return tinhtranglamviec.MapToTinhTrangLamViecDTOList(_mapper).ToList();
        }
    }
}
