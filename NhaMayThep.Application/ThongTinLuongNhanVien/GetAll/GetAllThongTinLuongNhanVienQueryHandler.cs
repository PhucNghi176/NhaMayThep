using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetAll
{
    public class GetAllThongTinLuongNhanVienQueryHandler : IRequestHandler<GetAllThongTinLuongNhanVieQuery, List<ThongTinLuongNhanVienDto>>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinLuongNhanVienQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _mapper = mapper;
        }


        public async Task<List<ThongTinLuongNhanVienDto>> Handle(GetAllThongTinLuongNhanVieQuery request, CancellationToken cancellationToken)
        {

            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var kReturn = k.Where(x => x.NgayXoa == null).ToList();

            return kReturn.MapToThongTinLuongNhanVienDtoList(_mapper);
        }
    }
}
