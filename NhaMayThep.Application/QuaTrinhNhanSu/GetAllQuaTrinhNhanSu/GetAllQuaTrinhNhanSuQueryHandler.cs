using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu
{
    public class GetAllQuaTrinhNhanSuQueryHandler : IRequestHandler<GetAllQuaTrinhNhanSuQuery, List<QuaTrinhNhanSuDto>>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        private readonly IThongTinQuaTrinhNhanSuRepository _loaiQuaTrinh;
        private readonly IPhongBanRepository _phongBan;
        private readonly IChucDanhRepository _chucDanh;
        private readonly IChucVuRepository _chucVu;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetAllQuaTrinhNhanSuQueryHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, IMapper mapper
            , IPhongBanRepository phongBanRepository
            , IChucDanhRepository chucDanhRepository
            , IChucVuRepository chucVuRepository
            , INhanVienRepository nhanVienRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _loaiQuaTrinh = thongTinQuaTrinhNhanSuRepository;
            _phongBan = phongBanRepository;
            _chucVu = chucVuRepository;
            _chucDanh = chucDanhRepository;
        }
        public async Task<List<QuaTrinhNhanSuDto>> Handle(GetAllQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var entity = await _quaTrinhNhanSuRepository.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ QuaTrinhNhanSu nào");
            }
            var hoVaTen = await _nhanVienRepository.FindAllToDictionaryAsync(
                x => x.NgayXoa == null && entity.Select(r => r.MaSoNhanVien).Contains(x.ID),
                x => x.ID,
                x => x.HoVaTen,
                cancellationToken);
            var loaiQuaTrinh = await _loaiQuaTrinh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var phongBan = await _phongBan.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucVu = await _chucVu.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucDanh = await _chucDanh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            return entity.MapToQuaTrinhNhanSuDtoList(_mapper, loaiQuaTrinh, phongBan, chucVu, chucDanh, hoVaTen);
        }
    }
}
