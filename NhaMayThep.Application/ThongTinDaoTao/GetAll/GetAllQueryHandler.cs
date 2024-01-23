using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinDaoTao;
using NhaMayThep.Application.ThongTinDaoTao.GetAll;

namespace NhaMayThep.Application.ThongTinDaoTao.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<ThongTinDaoTaoDto>>
    {
        private readonly IMapper _mapper;
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;

        public GetAllQueryHandler(IMapper mapper, IThongTinDaoTaoRepository thongTinDaoTaoRepository)
        {
            _mapper = mapper;
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
        }

        public async Task<List<ThongTinDaoTaoDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listThongTinDaoTao = await _thongTinDaoTaoRepository.FindAllAsync(x => x.NgayXoa ==null, cancellationToken);
            if (listThongTinDaoTao == null || listThongTinDaoTao.Count == 0)
            {
                throw new NotFoundException("Does Not Have Any ThongTinDaoTao");
            }
            return listThongTinDaoTao.MapToThongTinDaoTaoDtoList(_mapper);
        }
    }
}
