using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatHopDong
{
    public class GetHangLoatHopDongQueryHandler : IRequestHandler<GetHangLoatHopDongQuery, Dictionary<string, Dictionary<int, string>>>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IPhuCapRepository _phuCapRepository;

        public GetHangLoatHopDongQueryHandler(ILoaiHopDongReposity loaiHopDongReposity, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository, IPhuCapRepository phuCapRepository)
        {
            _loaiHopDongReposity = loaiHopDongReposity;
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _phuCapRepository = phuCapRepository;
        }


        // private readonly HESOLUONG

        public async Task<Dictionary<string, Dictionary<int, string>>> Handle(GetHangLoatHopDongQuery request, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, Dictionary<int, string>>();
            var loaiHopDong = await _loaiHopDongReposity.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var chucDanh = await _chucDanhRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var chucVu = await _chucVuRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var phuCap = await _phuCapRepository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);

            result.Add("LoaiHopDong", loaiHopDong.Select((x, i) => new { i, x.Name }).ToDictionary(x => x.i + 1, x => x.Name));
            result.Add("ChucDanh", chucDanh.Select((x, i) => new { i, x.Name }).ToDictionary(x => x.i + 1, x => x.Name));
            result.Add("ChucVu", chucVu.Select((x, i) => new { i, x.Name }).ToDictionary(x => x.i + 1, x => x.Name));
            result.Add("PhuCap", phuCap.Select((x, i) => new { i, x.Name }).ToDictionary(x => x.i + 1, x => x.Name));
            return result;
        }
    }
}
