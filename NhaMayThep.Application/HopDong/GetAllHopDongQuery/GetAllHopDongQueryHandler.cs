using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.HopDong.GetAllHopDongQuery
{
    public class GetAllHopDongQueryHandler : IRequestHandler<GetAllHopDongQuery, List<HopDongDto>>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly INhanVienRepository nhanVienRepository;
        //  private readonly IHeSoLuongRepository _heSoLuongRepository;
        public GetAllHopDongQueryHandler(IHopDongRepository hopDongRepository, IMapper mapper, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository, IPhuCapRepository phuCapRepository, ILoaiHopDongReposity loaiHopDongReposity, INhanVienRepository nhanVienRepository)
        {
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _phuCapRepository = phuCapRepository;
            _loaiHopDongReposity = loaiHopDongReposity;
            this.nhanVienRepository = nhanVienRepository;
        }
        public async Task<List<HopDongDto>> Handle(GetAllHopDongQuery query, CancellationToken cancellationToken)
        {
            var list = await _hopDongRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            var chucDanh = await _chucDanhRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var chucVu = await _chucVuRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var phuCap = await _phuCapRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var loaiHopDong = await _loaiHopDongReposity.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.Name, cancellationToken);
            var nhanVien = await nhanVienRepository.FindAllToDictionaryAsync(_ => _.NgayXoa == null, _ => _.ID, _ => _.HoVaTen, cancellationToken);
            var result = list.MapToListHopDongDto(_mapper, chucDanh, chucVu, phuCap, loaiHopDong, nhanVien);

            return result;
        }
    }
}
