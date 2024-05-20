using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThueSuat.GetThueSuatById
{
    public class GetThueSuatByIdQueryHandler : IRequestHandler<GetThueSuatByIdQuery, ThueSuatDTO>
    {
        private readonly IThueSuatRepository _repository;
        private readonly IMapper _mapper;
        public GetThueSuatByIdQueryHandler(IThueSuatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetThueSuatByIdQueryHandler() { }
        public async Task<ThueSuatDTO> Handle(GetThueSuatByIdQuery request, CancellationToken cancellationToken)
        {
            var thuesuat = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (thuesuat == null)
                throw new NotFoundException($"Không tìm thấy mục thuế với DI : {request.ID}");
            return thuesuat.MapToThueSuatDTO(_mapper);
        }
    }
}
