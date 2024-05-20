using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, NghiPhepDto>
    {
        private readonly IMapper _mapper;
        private readonly INghiPhepRepository _nghiPhepRepository;

        public GetByIdQueryHandler(IMapper mapper, INghiPhepRepository nghiPhepRepository)
        {
            _mapper = mapper;
            _nghiPhepRepository = nghiPhepRepository;
        }

        public async Task<NghiPhepDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var nghiPhep = await _nghiPhepRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);
            if (nghiPhep == null)
            {
                throw new NotFoundException("Không tìm thấy hoặc bản ghi nghỉ phép đã bị xóa trước đó!");
            }
            return _mapper.Map<NghiPhepDto>(nghiPhep);
        }
    }
}
