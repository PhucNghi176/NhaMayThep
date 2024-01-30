using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByIdDeletedQueryCommand : IRequestHandler<GetThongTinGiamTruGiaCanhByIdDeletedQuery, ThongTinGiamTruGiaCanhDto>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhByIdDeletedQueryCommand(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinGiamTruGiaCanhDto> Handle(GetThongTinGiamTruGiaCanhByIdDeletedQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository
                .FindAnyAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID != null && x.NgayXoa.HasValue,
                cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException("Thông tin giảm trừ gia cảnh này không bị xóa hoặc chưa  tồn tại");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDto(_mapper,
                            giamtrugiacanh.NhanVien.HoVaTen ?? "Trống",
                            giamtrugiacanh.ThongTinGiamTru.Name ?? "Trống");
        }
    }
}
