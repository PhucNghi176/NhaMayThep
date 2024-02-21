using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.GetAll
{
    public class GetAllMucSanPhamQueryHandler : IRequestHandler<GetAllMucSanPhamQuery, List<MucSanPhamDto>>
    {
        IMucSanPhamRepository _mucSanPhamRepository;
        IMapper _mapper;
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
