using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDQueryHandler : IRequestHandler<GetTinhTrangLamViecByIDQuery, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        public GetTinhTrangLamViecByIDQueryHandler(ITinhTrangLamViecRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TinhTrangLamViecDTO> Handle(GetTinhTrangLamViecByIDQuery request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.GetTinhTrangLamViecById(request.id, cancellationToken);
            if (tinhtranglamviec == null || tinhtranglamviec.NgayXoa != null)
                throw new NotFoundException($"Tình trạng làm việc với ID : {request.id} không tồn tại hoặc đã xóa.");
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
