using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.Test.TestTaoNhanVienHangLoat
{
    public class TaoNhanVienHangLoat : IRequest<List<string>>, ICommand
    {

        public int Ids { get; set; }
        public TaoNhanVienHangLoat(int ids)
        {
            Ids = ids;
        }


    }
    public class TaoNhanHangLoatHandler : IRequestHandler<TaoNhanVienHangLoat, List<string>>
    {
        private readonly INhanVienRepository _nhanVienRepository;

        public TaoNhanHangLoatHandler(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<List<string>> Handle(TaoNhanVienHangLoat request, CancellationToken cancellationToken)
        {
            List<string> nvs = new List<string>();
            //give me a random int           
            Random random = new Random();

            for (int i = 0; i <= request.Ids; i++)
            {
                int value = random.Next(1, 1000000);
                int value2 = random.Next(1, 1000000);
                var nv = new NhanVienEntity
                {
                    ChucVuID = 2,
                    Email = $"Test tạo hàng loạt + {value + value2}",
                    PasswordHash = "$2a$11$4sEpPFwr9/k7K.FxwjwsZeKmOl2.dPN4zCrdJb72o1BjmCFYFjECC",
                    HoVaTen = $"Test tạo hàng loạt + {i}",
                    TinhTrangLamViecID = 1,
                    NgayVaoCongTy = DateTime.Now,
                    DiaChiLienLac = $"Test tạo hàng loạt + {i}",
                    SoDienThoaiLienLac = "00000000000",
                    MaSoThue = $"Test tạo hàng loạt + {i}",
                    TenNganHang = $"Test tạo hàng loạt + {i}",
                    SoTaiKhoan = $"Test tạo hàng loạt + {i}",
                    DaCoHopDong = true
                };
                nvs.Add(nv.ID);
                _nhanVienRepository.Add(nv);
            }
            return nvs;
        }
    }
}
