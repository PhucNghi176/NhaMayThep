using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetTrangThaiDangKiCaLamViecById
{
    public class GetTrangThaiDangKiCaLamViecByIdQuery : IRequest<TrangThaiDangKiCaLamViecDTO>, IQuery
    {
        public GetTrangThaiDangKiCaLamViecByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
