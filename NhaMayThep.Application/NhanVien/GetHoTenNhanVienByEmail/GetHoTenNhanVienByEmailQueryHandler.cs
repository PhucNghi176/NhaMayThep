using MediatR;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
{
    public class GetHoTenNhanVienByEmailQueryHandler : IRequestHandler<GetHoTenNhanVienByEmailQuery, List<string>>
    {
        private readonly INhanVienRepository _repository;
        public GetHoTenNhanVienByEmailQueryHandler(INhanVienRepository repository)
        {
            _repository = repository;
        }
        public GetHoTenNhanVienByEmailQueryHandler() { }
        public async Task<List<string>> Handle(GetHoTenNhanVienByEmailQuery request, CancellationToken cancellationToken)
        {
            var hovaten = await this._repository.FindAllAsync(x => x.Email == request.Email && x.NgayXoa == null, cancellationToken);
            if (hovaten == null)
                throw new NotFoundException($"Không tìm thấy họ và tên của nhân viên có email:{request.Email}");
            List<string> result = new List<string>();
            foreach( var a in hovaten)
            {
                result.Add(a.HoVaTen);
            }
            return result;
        }
    }
}
