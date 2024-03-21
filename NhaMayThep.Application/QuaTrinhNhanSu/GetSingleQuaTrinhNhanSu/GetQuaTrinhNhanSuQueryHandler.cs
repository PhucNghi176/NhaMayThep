using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu
{
    public class GetQuaTrinhNhanSuQueryHandler : IRequestHandler<GetQuaTrinhNhanSuQuery, QuaTrinhNhanSuDto>
    {
        private readonly IMapper _mapper;
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IThongTinQuaTrinhNhanSuRepository _loaiQuaTrinh;
        private readonly IPhongBanRepository _phongBan;
        private readonly IChucDanhRepository _chucDanh;
        private readonly IChucVuRepository _chucVu;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetQuaTrinhNhanSuQueryHandler(IMapper mapper, IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IPhongBanRepository phongBanRepository
            , IChucDanhRepository chucDanhRepository
            , IChucVuRepository chucVuRepository
            , INhanVienRepository nhanVienRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _mapper = mapper;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _nhanVienRepository = nhanVienRepository;
            _loaiQuaTrinh = thongTinQuaTrinhNhanSuRepository;
            _phongBan = phongBanRepository;
            _chucVu = chucVuRepository;
            _chucDanh = chucDanhRepository;
        }
        public async Task<QuaTrinhNhanSuDto?> Handle(GetQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {            
            var entity = await _quaTrinhNhanSuRepository.FindAsync(x => x.ID == request.ID && x.NguoiXoaID == null, cancellationToken); 
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy quaTrinhNhanSu theo ID đã nhập");
            }
            var nhanVien = await _nhanVienRepository.FindAsync(x => x.NgayXoa == null && x.ID == entity.MaSoNhanVien, cancellationToken);
            var loaiQuaTrinh = await _loaiQuaTrinh.FindAsync(x => x.NgayXoa == null && x.ID == entity.LoaiQuaTrinhID, cancellationToken);
            var phongBan = await _phongBan.FindAsync(x => x.NgayXoa == null && x.ID == entity.PhongBanID, cancellationToken);
            var chucVu = await _chucVu.FindAsync(x => x.NgayXoa == null && x.ID == entity.ChucVuID, cancellationToken);
            var chucDanh = await _chucDanh.FindAsync(x => x.NgayXoa == null && x.ID == entity.ChucDanhID, cancellationToken);
            return entity.MapToQuaTrinhNhanSuDto(_mapper, loaiQuaTrinh.Name == null ? "Lỗi" : loaiQuaTrinh.Name
                , phongBan.Name == null ? "Lỗi" : phongBan.Name
                , chucVu.Name == null ? "Lỗi" : chucVu.Name
                , chucDanh.Name == null ? "Lỗi" : chucDanh.Name
                , nhanVien.HoVaTen == null ? "Lỗi" : nhanVien.HoVaTen);
        }
    }
}
