using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.KhenThuong.GetAllKhenThuong
{
    public class GetAllKhenThuongQueryHandler : IRequestHandler<GetAllKhenThuongQuery, List<KhenThuongDTO>>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;

        private readonly INhanVienRepository _nhanVienRepository;
        public GetAllKhenThuongQueryHandler(IKhenThuongRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public GetAllKhenThuongQueryHandler() { }
        public async Task<List<KhenThuongDTO>> Handle(GetAllKhenThuongQuery request, CancellationToken cancellationToken)
        {
            var khenthuong = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (khenthuong.Count() == 0)
                throw new NotFoundException("Không tìm thấy bất kỳ khen thưởng nào.");
            List<KhenThuongDTO> final = new List<KhenThuongDTO>();
            foreach (var item in khenthuong)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    break;
                KhenThuongDTO result = new KhenThuongDTO()
                {
                    MaSoNhanVien = item.MaSoNhanVien,
                    TenNhanVien = nhanvien.HoVaTen,
                    ID = item.ID,
                    ChinhSachNhanSuID = item.ChinhSachNhanSuID,
                    TenDotKhenThuong = item.TenDotKhenThuong,
                    NgayKhenThuong = item.NgayKhenThuong,
                    TongThuong = item.TongThuong,
                };
                final.Add(result);
            }
            return final;
        }
    }
}
