using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu
{
    public class GetQuaTrinhNhanSuQueryHandler : IRequestHandler<GetQuaTrinhNhanSuQuery, QuaTrinhNhanSuDto>
    {
        private readonly IMapper _mapper;
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        public GetQuaTrinhNhanSuQueryHandler(IMapper mapper, IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository)
        {
            _mapper = mapper;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }
        public async Task<QuaTrinhNhanSuDto?> Handle(GetQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            var entity = _quaTrinhNhanSuRepository.FindAsync(x => x.ID == request.ID).Result;
            return entity.MapToQuaTrinhNhanSuDto(_mapper);
        }
    }
}
