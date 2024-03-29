using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
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
            if(list == null)
            {
                throw new NotFoundException("Không tìm thấy chức vụ");
            }
            var result = list.MapToListChucDanhDto(_mapper);
            return result;
        }
    }
}
