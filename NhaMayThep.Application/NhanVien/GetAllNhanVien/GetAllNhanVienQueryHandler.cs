using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVien
{
    public class GetAllNhanVienQueryHandler : IRequestHandler<GetAllNhanVienQuery, List<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;
        public GetAllNhanVienQueryHandler(INhanVienRepository nhanvienReopsitory, IMapper mapper, IChucVuRepository chucvuRepository)
        {
            _nhanvienRepository = nhanvienReopsitory;
            _mapper = mapper;
            _chucVuRepository = chucvuRepository;
        }

        public async Task<List<NhanVienDto>> Handle(GetAllNhanVienQuery request, CancellationToken cancellationToken)
        {
            var list = await _nhanvienRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var returnList = new List<NhanVienDto>();
            foreach (var item in list)
            {
                var chucVu = await _chucVuRepository.FindAsync(x => x.ID == item.ChucVuID && x.NgayXoa == null, cancellationToken);
                var nvDto = _mapper.Map<NhanVienDto>(item);
                nvDto.ChucVu = chucVu.Name;
                returnList.Add(nvDto);
            }
            return returnList;


        }
    }
}
