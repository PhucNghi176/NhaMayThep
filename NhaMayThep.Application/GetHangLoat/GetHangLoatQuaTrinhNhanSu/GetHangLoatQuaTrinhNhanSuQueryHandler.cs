
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatQuaTrinhNhanSu
{
    public class GetHangLoatQuaTrinhNhanSuQueryHandler : IRequestHandler<GetHangLoatQuaTrinhNhanSuQuery, Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IThongTinQuaTrinhNhanSuRepository _loaiQuaTrinhRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        public GetHangLoatQuaTrinhNhanSuQueryHandler(IThongTinQuaTrinhNhanSuRepository loaiQuaTrinhRepository
            , IChucDanhRepository chucDanhRepository
            , IChucVuRepository chucVuRepository
            , IPhongBanRepository phongBanRepository)
        {
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _loaiQuaTrinhRepository = loaiQuaTrinhRepository;
            _phongBanRepository = phongBanRepository;
        }
        public async Task<Dictionary<string, List<KeyValuePair<int, string>>>> Handle(GetHangLoatQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, List<KeyValuePair<int, string>>>();
            var chucDanh = await _chucDanhRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var chucVu = await _chucVuRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var phongBan = await _phongBanRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var loaiQuaTrinh = await _loaiQuaTrinhRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);

            result.Add("ChucDanh", chucDanh.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList());
            result.Add("ChucVu", chucVu.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList());
            result.Add("PhongBan", phongBan.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList());
            result.Add("LoaiQuaTrinh", loaiQuaTrinh.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList());

            return result;
        }
    }
}
