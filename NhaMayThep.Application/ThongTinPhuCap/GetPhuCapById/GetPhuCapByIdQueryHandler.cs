using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById
{
    public class GetPhuCapByIdQueryHandler : IRequestHandler<GetPhuCapByIdQuery, PhuCapDto>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly IMapper _mapper;
        public GetPhuCapByIdQueryHandler(IPhuCapRepository phuCapRepository, IMapper mapper)
        {
            _phuCapRepository = phuCapRepository;
            _mapper = mapper;
        }
        public async Task<PhuCapDto> Handle(GetPhuCapByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _phuCapRepository.FindAsync(x => x.ID ==  query.ID && x.NgayXoa == null, cancellationToken);
            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Không tìm thấy phụ cấp với id: {query.ID}");
            return result.MapToPhuCapDto(_mapper);
        }
    }
}
