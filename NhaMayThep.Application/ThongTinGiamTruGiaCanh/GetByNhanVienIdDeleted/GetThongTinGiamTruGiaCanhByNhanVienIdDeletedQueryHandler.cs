using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery, List<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQueryHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinGiamTruGiaCanhDto>> Handle(GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery request, CancellationToken cancellationToken)
        {
            var giamtrugiacanh = await _thongTinGiamTruGiaCanhRepository
                .FindAllAsync(x => x.NhanVienID.Equals(request.Id) && x.NguoiXoaID != null && x.NgayXoa.HasValue,cancellationToken);
            if (giamtrugiacanh == null)
            {
                throw new NotFoundException($"Không tìm thấy bất kì thông tin giảm trừ gia cảnh bị xóa nào của nhân viên với Id: {request.Id}");
            }
            return giamtrugiacanh.MapToThongTinGiamTruGiaCanhDtoList(_mapper);
        }
    }
}
