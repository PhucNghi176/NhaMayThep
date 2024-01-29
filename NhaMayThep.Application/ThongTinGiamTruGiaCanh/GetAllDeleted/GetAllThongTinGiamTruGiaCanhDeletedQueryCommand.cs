using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllDeleted
{
    public class GetAllThongTinGiamTruGiaCanhDeletedQueryCommand : IRequestHandler<GetAllThongTinGiamTruGiaCanhDeletedQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        public GetAllThongTinGiamTruGiaCanhDeletedQueryCommand(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper,
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            INhanVienRepository nhanVienRepository)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetAllThongTinGiamTruGiaCanhDeletedQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanhs = await _thongTinGiamTruGiaCanhRepository
                            .FindAllAsync(x => x.NguoiXoaID != null && x.NgayXoa.HasValue,
                            cancellationToken);
            var thongtingiamtrus = await _thongTinGiamTruRepository
               .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            if (giamtrugiacanhs == null || !giamtrugiacanhs.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin giảm trừ gia cảnh nào bị xóa");
            }
            return giamtrugiacanhs.MapToThongTinGiamTruGiaCanhDtoList(_mapper, nhanviens, thongtingiamtrus);
        }
    }
}
