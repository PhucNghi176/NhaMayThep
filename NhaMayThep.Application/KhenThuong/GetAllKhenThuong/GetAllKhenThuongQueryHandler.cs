using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetAllKhenThuong
{
    public class GetAllKhenThuongQueryHandler : IRequestHandler<GetAllKhenThuongQuery, List<KhenThuongDTO>>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        public GetAllKhenThuongQueryHandler(IKhenThuongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetAllKhenThuongQueryHandler() { }
        public async Task<List<KhenThuongDTO>> Handle(GetAllKhenThuongQuery request, CancellationToken cancellationToken)
        {
            var khenthuong = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (khenthuong == null) 
                throw new NotFoundException("Không tìm thấy bất kỳ khen thưởng nào.");
            return khenthuong.MapToKhenThuongDTOList(_mapper).ToList();
        }
    }
}
