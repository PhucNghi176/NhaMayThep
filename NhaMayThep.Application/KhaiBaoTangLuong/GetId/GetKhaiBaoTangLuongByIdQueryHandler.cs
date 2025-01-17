﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetId
{
    public class GetKhaiBaoTangLuongByIDQueryHandler : IRequestHandler<GetKhaiBaoTangLuongByIdQuery, KhaiBaoTangLuongDto>
    {
        private readonly IKhaiBaoTangLuongRepository _repository;
        private readonly IMapper _mapper;
        public GetKhaiBaoTangLuongByIDQueryHandler(IKhaiBaoTangLuongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetKhaiBaoTangLuongByIDQueryHandler() { }
        public async Task<KhaiBaoTangLuongDto> Handle(GetKhaiBaoTangLuongByIdQuery request, CancellationToken cancellationToken)
        {
            var KhaiBaoTangLuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (KhaiBaoTangLuong == null)
                throw new NotFoundException($"không tìm thấy Khai Báo Tăng Lương vơi ID : {request.ID} hoặc đã bị xóa.");
            return KhaiBaoTangLuong.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
