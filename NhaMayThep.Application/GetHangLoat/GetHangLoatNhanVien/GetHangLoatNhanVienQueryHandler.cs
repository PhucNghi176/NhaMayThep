using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatNhanVien
{
    public class GetHangLoatQueryHandler : IRequestHandler<GetHangLoatNhanVienQuery, Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;

        public GetHangLoatQueryHandler(IChucVuRepository chucVuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository)
        {
            _chucVuRepository = chucVuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
        }

        public async Task<Dictionary<string, List<KeyValuePair<int, string>>>> Handle(GetHangLoatNhanVienQuery request, CancellationToken cancellationToken)
        {
            // find all value in chuc vu and trinh trang lam viec then combine and return
            var chucVu = await _chucVuRepository.FindAllAsync(cancellationToken);
            var trinhTrangLamViec = await _tinhTrangLamViecRepository.FindAllAsync(cancellationToken);

            var result = new Dictionary<string, List<KeyValuePair<int, string>>>
            {
                { "ChucVu", chucVu.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList() },
                { "TinhTrangLamViec", trinhTrangLamViec.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.Name)).ToList() }
            };


            return result;
        }
    }
}





