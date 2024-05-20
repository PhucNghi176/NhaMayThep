using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAll
{
    public class GetAllBaoHiemNhanVienChiTietBaoHiemQueryHandler : IRequestHandler<GetAllBaoHiemNhanVienChiTietBaoHiemQuery, List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTietRepository;
        private readonly IMapper _mapper;
        public GetAllBaoHiemNhanVienChiTietBaoHiemQueryHandler(IBaoHiemNhanVienBaoHiemChiTietRepository baohiemNhanVienChiTietRepository, IMapper mapper)
        {
            _baohiemNhanVienChiTietRepository = baohiemNhanVienChiTietRepository;
            _mapper = mapper;
        }

        public async Task<List<BaoHiemNhanVienChiTietBaoHiemDto>> Handle(GetAllBaoHiemNhanVienChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            var listExists = await _baohiemNhanVienChiTietRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue, cancellationToken);
            if (listExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bảo hiểm nào");
            }
            return listExists.MapFullToBaoHiemNhanVienChiTietDtoToList(_mapper);
        }
    }
}
