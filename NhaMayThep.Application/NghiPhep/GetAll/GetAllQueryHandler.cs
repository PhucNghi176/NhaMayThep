using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.NghiPhep.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<NghiPhepDto>>
    {
        private readonly IMapper _mapper;
        private readonly INghiPhepRepository _nghiPhepRepository;

        public GetAllQueryHandler(IMapper mapper, INghiPhepRepository nghiPhepRepository)
        {
            _mapper = mapper;
            _nghiPhepRepository = nghiPhepRepository;
        }

        public async Task<List<NghiPhepDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listNghiPhep = await _nghiPhepRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (listNghiPhep == null || listNghiPhep.Count == 0)
            {
                throw new NotFoundException("Không có Nghỉ Phép nào!");
            }
            return _mapper.Map<List<NghiPhepDto>>(listNghiPhep);
        }
    }
}
