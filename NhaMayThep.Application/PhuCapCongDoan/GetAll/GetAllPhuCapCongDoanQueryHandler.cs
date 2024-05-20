using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.PhuCapCongDoan.GetAll
{
    public class GetAllPhuCapCongDoanQueryHandler : IRequestHandler<GetAllPhuCapCongDoanQuery, List<PhuCapCongDoanDto>>
    {
        IPhuCapCongDoanRepository _PhuCapCongDoanRepository;
        IMapper _mapper;
        public GetAllPhuCapCongDoanQueryHandler(IPhuCapCongDoanRepository PhuCapCongDoanRepository, IMapper mapper)
        {
            _PhuCapCongDoanRepository = PhuCapCongDoanRepository;
            _mapper = mapper;
        }

        public async Task<List<PhuCapCongDoanDto>> Handle(GetAllPhuCapCongDoanQuery request, CancellationToken cancellationToken)
        {
            var entity = await _PhuCapCongDoanRepository.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ Phụ Cấp Công Đoàn nào");
            }
            return entity.MapToPhuCapCongDoanDtoList(_mapper);
        }
    }
}
