using AutoMapper;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinDaoTao;
using NhaMayThep.Application.ThongTinDaoTao.GetById;
using NhaMapThep.Domain.Common.Exceptions;

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
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindByIdAsync(request.Id, cancellationToken);
            if (thongTinDaoTao == null || thongTinDaoTao.NgayXoa != null)
            {
                throw new NotFoundException("ThongTinDaoTao Does not Exist");
            }
            return thongTinDaoTao.MapToThongTinDaoTaoDto(_mapper);
        }
    }
}
