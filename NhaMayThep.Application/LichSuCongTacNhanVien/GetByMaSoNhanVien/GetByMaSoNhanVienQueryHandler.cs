using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiCongTac;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienQueryHandler : IRequestHandler<GetByMaSoNhanVienQuery, List<LichSuCongTacNhanVienDto>>
    {

        public readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        public readonly IMapper _mapper;

        public GetByMaSoNhanVienQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<List<LichSuCongTacNhanVienDto>> Handle(GetByMaSoNhanVienQuery request, CancellationToken cancellationToken)
        {
            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null,
                cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Rỗng");
            }
            foreach (var item in list)
            {
                item.LoaiCongTac.MapToLoaiCongTacDto(_mapper);
            }
            return list.MapToLichSuCongTacNhanVienDtoList(_mapper);
        }
    }
}
