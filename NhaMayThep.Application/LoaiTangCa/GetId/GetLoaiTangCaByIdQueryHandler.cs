using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetId
{
    public class GetLoaiTangCaByIdQueryHandler : IRequestHandler<GetLoaiTangCaByIdQuery, LoaiTangCaDto>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;


        public GetLoaiTangCaByIdQueryHandler(ILoaiTangCaRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LoaiTangCaDto> Handle(GetLoaiTangCaByIdQuery request, CancellationToken cancellationToken)
        {
            var loaiTangCa = await this._repository.FindAsync(x => x.ID.Equals(request.id) && x.NgayXoa == null, cancellationToken);
            if (loaiTangCa == null)
                throw new NotFoundException($"không tìm thấy Loại Tăng Ca với ID : {request.id} hoặc đã bị xóa.");

            return loaiTangCa.MapToLoaiTangCaDto(_mapper);
        }

    }
}
