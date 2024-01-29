using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetById
{
    public class GetChiTietNgayNghiPhepByIdQueryHandler : IRequestHandler<GetChiTietNgayNghiPhepByIdQuery, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepository _repository;
        private readonly IMapper _mapper;

        public GetChiTietNgayNghiPhepByIdQueryHandler(IChiTietNgayNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(GetChiTietNgayNghiPhepByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAnyAsync(x => x.ID == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"Entity với ID {request.Id} không tìm thấy");
            }
            if (entity.NgayXoa != null)
            {
                throw new NotFoundException($"Entity với ID {request.Id} đã bị xóa");
            }

            return _mapper.Map<ChiTietNgayNghiPhepDto>(entity);
        }
    }
}
