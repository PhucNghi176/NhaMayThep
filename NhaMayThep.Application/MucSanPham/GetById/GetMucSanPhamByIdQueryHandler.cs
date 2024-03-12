using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.GetById
{
    public class GetMucSanPhamByIdQueryHandler : IRequestHandler<GetMucSanPhamByIdQuery, MucSanPhamDto>
    {
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        private readonly IMapper _mapper;
        public GetMucSanPhamByIdQueryHandler(IMucSanPhamRepository mucSanPhamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<MucSanPhamDto> Handle(GetMucSanPhamByIdQuery request, CancellationToken cancellationToken)
        {
            var existEntity = await _mucSanPhamRepository.FindAsync(x => x.ID == request.ID && x.NguoiXoaID == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToMucSanPhamDto(_mapper);
        }
    }
}
