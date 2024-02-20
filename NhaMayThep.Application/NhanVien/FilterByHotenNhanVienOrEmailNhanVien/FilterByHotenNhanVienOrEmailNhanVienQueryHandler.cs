using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
{
    public class FilterByHotenNhanVienOrEmailNhanVienQueryHandler : IRequestHandler<FilterByHotenNhanVienOrEmailNhanVienQuery, List<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterByHotenNhanVienOrEmailNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQueryHandler() { }
        public async Task<List<NhanVienDto>> Handle(FilterByHotenNhanVienOrEmailNhanVienQuery request, CancellationToken cancellationToken)
        {
            var result = await this._repository.FindAllAsync(x => (x.Email.Contains(request.request) && x.NgayXoa == null) || (x.HoVaTen.Contains(request.request) && x.NgayXoa == null), cancellationToken);    
            if (result == null)
                throw new NotFoundException("Không tìm nhân viên");
            return result.MapToNhanVienDtoList(_mapper).ToList();
        }
    }
}
