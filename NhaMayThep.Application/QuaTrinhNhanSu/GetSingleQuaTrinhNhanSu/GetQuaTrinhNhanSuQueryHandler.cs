using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;

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
            var entity = await _quaTrinhNhanSuRepository.FindAsync(x => x.ID == request.ID && x.NguoiXoaID == null);           
            return entity.MapToQuaTrinhNhanSuDto(_mapper);
        }
    }
}
