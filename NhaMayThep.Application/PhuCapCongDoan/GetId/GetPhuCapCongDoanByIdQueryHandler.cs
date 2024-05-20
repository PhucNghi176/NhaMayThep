using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.PhuCapCongDoan.GetId
{
    public class GetPhuCapCongDoanByIdQueryHandler : IRequestHandler<GetPhuCapCongDoanByIdQuery, PhuCapCongDoanDto>
    {
        IPhuCapCongDoanRepository _PhuCapCongDoanRepository;
        IMapper _mapper;
        public GetPhuCapCongDoanByIdQueryHandler(IPhuCapCongDoanRepository PhuCapCongDoanRepository, IMapper mapper)
        {
            _mapper = mapper;
            _PhuCapCongDoanRepository = PhuCapCongDoanRepository;
        }
        public async Task<PhuCapCongDoanDto> Handle(GetPhuCapCongDoanByIdQuery request, CancellationToken cancellationToken)
        {
            var existEntity = await _PhuCapCongDoanRepository.FindAsync(x => x.ID == request.ID && x.NguoiXoaID == null);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToPhuCapCongDoanDto(_mapper);
        }
    }
}
