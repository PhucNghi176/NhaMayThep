using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVien
{
    public class GetNhanVienQueryHandler : IRequestHandler<GetNhanVienQuery, NhanVienDto>
    {

        private readonly INhanVienRepository _repository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper, IChucVuRepository chucVuRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
        }

        public async Task<NhanVienDto> Handle(GetNhanVienQuery request, CancellationToken cancellationToken)
        {
            var nv = await _repository.FindAsync(x => x.Email == request.Predicate || x.ID == request.Predicate);
            //find chuc vu name by nv .ChucVuID and give me only chucvu name

            
            if (nv is null)
            {
                throw new NotFoundException($"Khong tim thay nhan vien voi thong tin - {request.Predicate}");
            }
            var chucVuName = await _chucVuRepository.FindAsync(x => x.ID == nv.ChucVuID, cancellationToken);
            // map chucvuName to the return object
            var nvDto = _mapper.Map<NhanVienDto>(nv);
            nvDto.ChucVu = chucVuName.Name;
            return nvDto;

        }
    }

}

