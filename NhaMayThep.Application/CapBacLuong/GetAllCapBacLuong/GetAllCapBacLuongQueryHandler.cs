using MediatR;
using NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.CapBacLuong.GetAllCapBacLuong
{
    public class GetAllCapBacLuongQueryHandler : IRequestHandler<GetAllCapBacLuongQuery, List<CapbacLuongDto>>
    {
        private readonly ICapBacLuongRepository _CapBacLuongRepository;
        private readonly IMapper _mapper;

        public GetAllCapBacLuongQueryHandler(ICapBacLuongRepository CapBacLuongRepository, IMapper mapper)
        {
            _CapBacLuongRepository = CapBacLuongRepository;
            _mapper = mapper;
        }

        public async Task<List<CapbacLuongDto>> Handle(GetAllCapBacLuongQuery request, CancellationToken cancellationToken)
        {

            var CapBacLuongList = await _CapBacLuongRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            return CapBacLuongList.MapToCapBacLuongDtoList(_mapper);
        }
    }
}
