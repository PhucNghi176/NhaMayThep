using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVienIDByEmail
{
    public class GetNhanVienIDByEmailQueryHandler : IRequestHandler<GetNhanVienIDByEmailQuery, string>
    {
        private readonly INhanVienRepository _repository;
        public GetNhanVienIDByEmailQueryHandler(INhanVienRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(GetNhanVienIDByEmailQuery request, CancellationToken cancellationToken)
        {
            var ID = await _repository.FindAsync(x => x.Email == request.Email && x.NgayXoa == null, cancellationToken);
            if (ID == null)
            {
                throw new NotFoundException($"Khong tim thay nhan vien voi email {request.Email}");
            }
            return ID.ID;
        }
    }

}

