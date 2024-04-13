using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu
{
    public class GetAllQuaTrinhNhanSuQueryHandler : IRequestHandler<GetAllQuaTrinhNhanSuQuery, List<QuaTrinhNhanSuDto>>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        public GetAllQuaTrinhNhanSuQueryHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, IMapper mapper)
        {
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<List<QuaTrinhNhanSuDto>> Handle(GetAllQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var entity = await _quaTrinhNhanSuRepository.FindAllAsync(x => x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ QuaTrinhNhanSu nào");
            }
            return entity.MapToQuaTrinhNhanSuDtoList(_mapper);
        }
    }
}
