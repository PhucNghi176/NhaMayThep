using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh
{
    public class GetAllChucDanhQueryHandler : IRequestHandler<GetAllChucDanhQuery, List<ChucDanhDto>>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IMapper _mapper;
        public GetAllChucDanhQueryHandler(IChucDanhRepository chucDanhRepository, IMapper mapper)
        {
            _chucDanhRepository = chucDanhRepository;
            _mapper = mapper;
        }
        public async Task<List<ChucDanhDto>> Handle(GetAllChucDanhQuery query, CancellationToken cancellationToken)
        {
            var list = await _chucDanhRepository.FindAllAsync(x => x.NgayXoa == null,cancellationToken);
            List<ChucDanhDto> result = new List<ChucDanhDto>();
            foreach (var item in list)
            {
                if (item.NgayXoa != null)
                    continue;
                var add = item.MapToChucDanhDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
