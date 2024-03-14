using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.GetAll
{
    public class GetAllPhuCapNhanVienQueryHandler : IRequestHandler<GetAllPhuCapNhanVienQuery, List<PhuCapNhanVienDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPhuCapNhanVienRepository _phuCapNhanVienRepository;

        public GetAllPhuCapNhanVienQueryHandler(IMapper mapper, IPhuCapNhanVienRepository phuCapNhanVienRepository)
        {
            _mapper = mapper;
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
        }
        public async Task<List<PhuCapNhanVienDto>> Handle(GetAllPhuCapNhanVienQuery request, CancellationToken cancellationToken)
        {
            var phuCapNhanVienList = await _phuCapNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (phuCapNhanVienList == null || !phuCapNhanVienList.Any())
            {
                throw new NotFoundException("Không có phụ cấp nhân viên nào!");
            }
            return phuCapNhanVienList.MapToPhuCapNhanVienDtoList(_mapper);
        }
    }
}
