using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiCongTac;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienQueryHandler : IRequestHandler<GetByMaSoNhanVienQuery, List<LichSuCongTacNhanVienDto>>
    {

        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public GetByMaSoNhanVienQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<List<LichSuCongTacNhanVienDto>> Handle(GetByMaSoNhanVienQuery request, CancellationToken cancellationToken)
        {
            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null,
                cancellationToken);

            if (list is null)
                throw new NotFoundException("Danh Sách Rỗng");

            foreach (var item in list)
                item.LoaiCongTac.MapToLoaiCongTacDto(_mapper);

            var result = list.MapTolichSuCongTacNhanVienDtoList(_mapper);
            foreach (var item in result)
            {
                var nameSearching = await _nhanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien), cancellationToken);
                item.HoVaTen = nameSearching.HoVaTen;
            }
            return result;
        }
    }
}
