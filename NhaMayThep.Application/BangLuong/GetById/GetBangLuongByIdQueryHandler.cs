using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.BangLuong.GetById;
using NhaMayThep.Application.BangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.GetById
{
    public class GetBangLuongByIdQueryHandler : IRequestHandler<GetBangLuongByIdQuery, BangLuongDto>
    {
        private readonly IBangLuongRepository _repository;
        private readonly IMapper _mapper;


        public GetBangLuongByIdQueryHandler(IBangLuongRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<BangLuongDto> Handle(GetBangLuongByIdQuery request, CancellationToken cancellationToken)
        {
            var BangLuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (BangLuong == null)
                throw new NotFoundException($"không tìm thấy Bảng Lương với ID : {request.ID} hoặc đã bị xóa.");

            return BangLuong.MapToBangLuongDto(_mapper);
        }

    }
}
