using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetById
{
    public class GetMaDangKiCaLamByIdHandler : IRequestHandler<GetMaDangKiCaLamByIdQuery, MaDangKiCaLamViecDTO>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public GetMaDangKiCaLamByIdHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<MaDangKiCaLamViecDTO> Handle(GetMaDangKiCaLamByIdQuery request, CancellationToken cancellationToken)
        {
            var dangKi = await _maDangKiCaLamRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKi is null || dangKi.NgayXoa.HasValue)
            {
                throw new NotFoundException("Trạng Thái không tìm thấy hoặc đã bị xóa");
            }
            return dangKi.MapToMaDangKiCaLamViecDTO(_mapper);
        }
    }
}
