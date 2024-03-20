using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetById
{
    public class GetByIdBaoHiemNhanVienQueryHandler : IRequestHandler<GetByIdQuery, BaoHiemNhanVienDto>
    {
        private readonly IMapper _mapper;
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;

        public GetByIdBaoHiemNhanVienQueryHandler(IMapper mapper, IBaoHiemNhanVienRepository baoHiemNhanVienRepository)
        {
            _mapper = mapper;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
        }

        public async Task<BaoHiemNhanVienDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var baoHiemNhanVien = await _baoHiemNhanVienRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);
            if (baoHiemNhanVien == null)
            {
                throw new NotFoundException("Không tìm thấy hoặc bản ghi bảo hiểm nhân viên đã bị xóa trước đó!");
            }
            return _mapper.Map<BaoHiemNhanVienDto>(baoHiemNhanVien);
        }
    }
}
