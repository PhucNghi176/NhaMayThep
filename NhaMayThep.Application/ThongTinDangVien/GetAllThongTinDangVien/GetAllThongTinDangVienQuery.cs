using MediatR;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien
{
    public class GetAllThongTinDangVienQuery : IRequest<List<ThongTinDangVienDto>>
    {
    }
}
