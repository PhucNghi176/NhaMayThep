using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.KyLuat.GetKyLuatById
{
    public class GetKyLuatByIDQueryHandler : IRequestHandler<GetKyLuatByIDQuery, KyLuatDTO>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetKyLuatByIDQueryHandler(IKyLuatRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public GetKyLuatByIDQueryHandler() { }
        public async Task<KyLuatDTO> Handle(GetKyLuatByIDQuery request, CancellationToken cancellationToken)
        {
            var kyluat = await this._repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (kyluat == null)
                throw new NotFoundException($"Không tìm thấy trường hợp kỷ luật nào với ID : {request.Id} hoặc trường hợp này đã bị xóa.");
            var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(kyluat.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
                throw new NotFoundException($"Không tìm thấy nhân viên nào với ID : {request.Id} hoặc nhân viên này đã bị xóa.");
            KyLuatDTO result = new KyLuatDTO()
            {
                Id = kyluat.ID,
                MaSoNhanVien = kyluat.MaSoNhanVien,
                tenNhanVien = nhanvien.HoVaTen,
                ChinhSachNhanSuID = kyluat.ChinhSachNhanSuID,
                TenDotKyLuat = kyluat.TenDotKyLuat,
                NgayKiLuat = kyluat.NgayKiLuat,
                TongPhat = kyluat.TongPhat
            };
            return result;
        }
    }
}
