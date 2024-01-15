using MediatR;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien
{
    public class GetAllChiTietDangVienQuery : IRequest<List<ChiTietDangVienDto>>
    {
    }
}
