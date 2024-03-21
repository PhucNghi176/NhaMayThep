using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQueryHandler : IRequestHandler<GetKhenThuongByIDQuery, KhenThuongDTO>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetKhenThuongByIDQueryHandler(IKhenThuongRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public GetKhenThuongByIDQueryHandler() { }
        public async Task<KhenThuongDTO> Handle(GetKhenThuongByIDQuery request, CancellationToken cancellationToken)
        {
            var khenthuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (khenthuong == null)
                throw new NotFoundException($"không tìm thấy khen thưởng với ID : {request.ID} hoặc mục khen thưởng này đã bị xóa.");
            var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(khenthuong.MaSoNhanVien) &&  x.NgayXoa == null, cancellationToken );
            if (nhanvien == null)
                throw new NotFoundException($"không tìm thấy nhân viên với ID : {khenthuong.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            KhenThuongDTO result = new KhenThuongDTO()
            {
                MaSoNhanVien = khenthuong.MaSoNhanVien,
                TenNhanVien = nhanvien.HoVaTen,
                ID = khenthuong.ID,
                ChinhSachNhanSuID = khenthuong.ChinhSachNhanSuID,
                TenDotKhenThuong = khenthuong.TenDotKhenThuong,
                NgayKhenThuong = khenthuong.NgayKhenThuong,
                TongThuong = khenthuong.TongThuong,
            };
            return result;
        }
    }
}
