using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThueSuat.GetAllThueSuat
{
    public class GetAllThueSuatQueryHandler : IRequestHandler<GetAllThueSuatQuery, List<ThueSuatDTO>>
    {
        private readonly IThueSuatRepository _repository;
        private readonly IMapper _mapper;
        public GetAllThueSuatQueryHandler(IThueSuatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetAllThueSuatQueryHandler() { }
        public async Task<List<ThueSuatDTO>> Handle(GetAllThueSuatQuery request, CancellationToken cancellationToken)
        {
            var thuesuat = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (thuesuat == null)
                throw new NotFoundException("Không tìm thấy mục thuế suất nào.");
            return thuesuat.MapToThueSuatDTOList(_mapper).ToList();
        }
    }
}
