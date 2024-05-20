using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.PhiCongDoan.GetAll
{
    public class GetAllPhiCongDoanQueryHandler : IRequestHandler<GetAllPhiCongDoanQuery, List<PhiCongDoanDto>>
    {
        private readonly IPhiCongDoanRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPhiCongDoanQueryHandler(IPhiCongDoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PhiCongDoanDto>> Handle(GetAllPhiCongDoanQuery request, CancellationToken cancellationToken)
        {
            var PhiCongDoan = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (PhiCongDoan == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Phí Công Đoàn nào.");
            return PhiCongDoan.MapToPhiCongDoanDtoList(_mapper).ToList();

        }
    }
}
