using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.NghiPhep.GetById;
using NhaMayThep.Application.NghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetNghiPhepByIdQueryHandler : IRequestHandler<GetNghiPhepByIdQuery, NghiPhepDto>
    {
        private readonly INghiPhepRepository _repository;
        private readonly IMapper _mapper;


        public GetNghiPhepByIdQueryHandler(INghiPhepRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<NghiPhepDto> Handle(GetNghiPhepByIdQuery request, CancellationToken cancellationToken)
        {
            var NghiPhep = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (NghiPhep == null)
                throw new NotFoundException($"không tìm thấy Nghỉ Phép với ID : {request.ID} hoặc đã bị xóa.");

            return NghiPhep.MapToNghiPhepDto(_mapper);
        }

    }
}
