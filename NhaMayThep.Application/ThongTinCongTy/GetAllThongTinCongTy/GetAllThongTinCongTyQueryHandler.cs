using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinCongTy.GetAllThongTinCongTy
{
    public class GetAllThongTinCongTyQueryHandler : IRequestHandler<GetAllThongTinCongTyQuery, List<ThongTinCongTyDto>>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly IMapper _mapper;

        public GetAllThongTinCongTyQueryHandler(IThongTinCongTyRepository thongTinCongTyRepository, IMapper mapper)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinCongTyDto>> Handle(GetAllThongTinCongTyQuery request, CancellationToken cancellationToken)
        {
            var thongTinCongTys = await _thongTinCongTyRepository.FindAllAsync(t => t.NgayXoa == null, cancellationToken);
            if (thongTinCongTys is null || !thongTinCongTys.Any())
                throw new NotFoundException("Do not any ThongTinCongTy");
            List<ThongTinCongTyDto> list = new List<ThongTinCongTyDto>();
            foreach (var thongTinCongTy in thongTinCongTys)
            {
                list.Add(thongTinCongTy.MapToThongTinCongTyDto(_mapper));
            }
            return list;
        }
    }
}