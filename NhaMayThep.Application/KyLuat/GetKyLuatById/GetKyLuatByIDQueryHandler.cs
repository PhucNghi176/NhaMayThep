using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetKyLuatById
{
    public class GetKyLuatByIDQueryHandler : IRequestHandler<GetKyLuatByIDQuery, KyLuatDTO>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        public async Task<KyLuatDTO> Handle(GetKyLuatByIDQuery request, CancellationToken cancellationToken)
        {
            var kyluat = await this._repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null , cancellationToken);
            if (kyluat == null)
                throw new NotFoundException($"Không tìm thấy trường hợp kỷ luật nào với ID : {request.Id} hoặc trường hợp này đã bị xóa.");
            return kyluat.MapToKyLuatDTO(_mapper);
        }
    }
}
