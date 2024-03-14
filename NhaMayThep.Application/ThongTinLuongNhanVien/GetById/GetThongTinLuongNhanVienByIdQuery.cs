using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByIdQuery : IRequest<ThongTinLuongNhanVienDTO>, IQuery
    {
        public string Id { get; set; }
        public GetThongTinLuongNhanVienByIdQuery(string id)
        {
            Id = id;
        }
    }
}
