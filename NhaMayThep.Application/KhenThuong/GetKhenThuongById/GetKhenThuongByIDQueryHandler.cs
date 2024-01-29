using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQueryHandler : IRequestHandler<GetKhenThuongByIDQuery, KhenThuongDTO>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        public GetKhenThuongByIDQueryHandler(IKhenThuongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetKhenThuongByIDQueryHandler() { }
        public async Task<KhenThuongDTO> Handle(GetKhenThuongByIDQuery request, CancellationToken cancellationToken)
        {
            var khenthuong = await this._repository.FindAnyAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (khenthuong == null)
                throw new NotFoundException($"không tìm thấy khen thưởng vơi ID : {request.ID} hoặc nó khen thưởng này đã bị xóa.");
            return khenthuong.MapToKhenThuongDTO(_mapper);
        }
    }
}
