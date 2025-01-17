﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.MucSanPham.GetAll
{
    public class GetAllMucSanPhamQueryHandler : IRequestHandler<GetAllMucSanPhamQuery, List<MucSanPhamDto>>
    {
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        private readonly IMapper _mapper;
        public GetAllMucSanPhamQueryHandler(IMucSanPhamRepository mucSanPhamRepository, IMapper mapper)
        {
            _mucSanPhamRepository = mucSanPhamRepository;
            _mapper = mapper;
        }

        public async Task<List<MucSanPhamDto>> Handle(GetAllMucSanPhamQuery request, CancellationToken cancellationToken)
        {
            var entity = await _mucSanPhamRepository.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ MucSanPham nào");
            }
            return entity.MapToMucSanPhamDtoList(_mapper);
        }
    }
}
