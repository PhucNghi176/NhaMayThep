using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQueryHandler : IRequestHandler<GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery, List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQueryHandler(IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository, IMapper mapper)
        {
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _mapper = mapper;
        }
        public async Task<List<BaoHiemNhanVienChiTietBaoHiemDto>> Handle(GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var listExists = await _baohiemNhanVienChiTietRepository
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.NguoiXoaID) && x.NgayXoa.HasValue, cancellationToken);
            if (listExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bảo hiểm nào");
            }
            return listExists.MapFullToBaoHiemNhanVienChiTietDtoToList(_mapper);
        }
    }
}
