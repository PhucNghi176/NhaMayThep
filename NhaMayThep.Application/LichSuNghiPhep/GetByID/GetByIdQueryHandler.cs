using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByID
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, LichSuNghiPhepDto>
    {
        private readonly ILichSuNghiPhepRepository _repo;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ILichSuNghiPhepRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<LichSuNghiPhepDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);

            if (lsnp == null)
            {
                throw new NotFoundException($"LichSuNghiPhep với Id: {request.Id} không tìm thấy .");
            }
            if(lsnp.NgayXoa != null)
            {
                throw new NotFoundException($"LichSuNghiPhep với Id  {request.Id} đã xóa");
            }

            return _mapper.Map<LichSuNghiPhepDto>(lsnp);
        }
    }
}