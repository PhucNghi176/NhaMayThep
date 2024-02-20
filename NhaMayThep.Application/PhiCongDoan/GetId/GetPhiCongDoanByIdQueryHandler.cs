using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.PhiCongDoan.GetId;
using NhaMayThep.Application.PhiCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.GetId
{
    public class GetPhiCongDoanByIdQueryHandler : IRequestHandler<GetPhiCongDoanByIdQuery, PhiCongDoanDto>
    {
        private readonly IPhiCongDoanRepository _repository;
        private readonly IMapper _mapper;


        public GetPhiCongDoanByIdQueryHandler(IPhiCongDoanRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<PhiCongDoanDto> Handle(GetPhiCongDoanByIdQuery request, CancellationToken cancellationToken)
        {
            var phiCongDoan = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (phiCongDoan == null)
                throw new NotFoundException($"Không tìm thấy Phí Công Đoàn với ID : {request.ID} hoặc đã bị xóa.");

            return phiCongDoan.MapToPhiCongDoanDto(_mapper);
        }

    }
}
