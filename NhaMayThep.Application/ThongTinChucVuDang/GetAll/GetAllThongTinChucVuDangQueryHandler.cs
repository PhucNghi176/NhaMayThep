using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;

namespace NhaMayThep.Application.ThongTinChucVuDang.GetAll
{
    public class GetAllThongTinChucVuDangQueryHandler : IRequestHandler<GetAllThongTinChucVuDangQuery, List<ThongTinChucVuDangDto>>
    {
        private readonly IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinChucVuDangQueryHandler(IThongTinChucVuDangRepository thongTinChucVuDangRepository, IMapper mapper)
        {
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinChucVuDangDto>> Handle(GetAllThongTinChucVuDangQuery query, CancellationToken cancellationToken)
        {
            var thongTinChucVuDangList = await _thongTinChucVuDangRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (thongTinChucVuDangList == null || !thongTinChucVuDangList.Any())
            {
                throw new NotFoundException("Không có thông tin chức vụ đảng nào!");
            }
            return thongTinChucVuDangList.MapToThongTinChucVuDangDtoList(_mapper);
        }
    }
}
