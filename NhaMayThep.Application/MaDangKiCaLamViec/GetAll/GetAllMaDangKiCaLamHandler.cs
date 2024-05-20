using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetAll
{
    public class GetAllMaDangKiCaLamHandler : IRequestHandler<GetAllMaDangKiCaLamQuery, List<MaDangKiCaLamViecDTO>>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public GetAllMaDangKiCaLamHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<List<MaDangKiCaLamViecDTO>> Handle(GetAllMaDangKiCaLamQuery request, CancellationToken cancellationToken)
        {
            var list = await _maDangKiCaLamRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToMaDangKiCaLamViecDTOList(_mapper);
        }
    }
}
