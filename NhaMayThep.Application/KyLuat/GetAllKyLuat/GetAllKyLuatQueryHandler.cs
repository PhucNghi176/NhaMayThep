using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.KhenThuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetAllKyLuat
{
    public class GetAllKyLuatQueryHandler : IRequestHandler<GetAllKyLuatQuery, List<KyLuatDTO>>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetAllKyLuatQueryHandler(IKyLuatRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public GetAllKyLuatQueryHandler() { }
        public async Task<List<KyLuatDTO>> Handle(GetAllKyLuatQuery request, CancellationToken cancellationToken)
        {
            var kyluat = await this._repository.FindAllAsync(x => x.NgayXoa == null,cancellationToken);
            if(kyluat.Count() == 0) 
                throw new NotFoundException("Không tìm thấy trường hợp kỷ luật nào.");
            List<KyLuatDTO> final = new List<KyLuatDTO>();
            foreach (var item in kyluat)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    break;
                KyLuatDTO result = new KyLuatDTO()
                {
                    MaSoNhanVien = item.MaSoNhanVien,
                    tenNhanVien = nhanvien.HoVaTen,
                    Id = item.ID,
                    ChinhSachNhanSuID = item.ChinhSachNhanSuID,
                    TenDotKyLuat = item.TenDotKyLuat,
                    NgayKiLuat = item.NgayKiLuat,
                    TongPhat = item.TongPhat,
                };
                final.Add(result);
            }
            return final;
        }
    }
}
