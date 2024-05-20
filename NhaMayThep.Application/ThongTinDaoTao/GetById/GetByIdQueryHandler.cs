using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinDaoTao.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ThongTinDaoTaoDto>
    {
        private readonly IMapper _mapper;
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;

        public GetByIdQueryHandler(IMapper mapper, IThongTinDaoTaoRepository thongTinDaoTaoRepository)
        {
            _mapper = mapper;
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
        }

        public async Task<ThongTinDaoTaoDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (thongTinDaoTao == null || thongTinDaoTao.NgayXoa != null)
            {
                throw new NotFoundException("Thông Tin Đào Tạo không tồn tại!");
            }
            return thongTinDaoTao.MapToThongTinDaoTaoDto(_mapper);
        }
    }
}
