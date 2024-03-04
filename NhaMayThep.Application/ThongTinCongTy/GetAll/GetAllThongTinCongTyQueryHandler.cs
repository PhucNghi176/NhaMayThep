using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinCongTy.GetAll;
using NhaMayThep.Application.ThongTinCongTy;

namespace NhaMayThep.Application.ThongTinCongTy.GetAll
{
    public class GetAllThongTinCongTyQueryHandler : IRequestHandler<GetAllThongTinCongTyQuery, List<ThongTinCongTyDto>>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinCongTyQueryHandler(IThongTinCongTyRepository thongTinCongTyRepository,IMapper mapper)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinCongTyDto>> Handle(GetAllThongTinCongTyQuery request, CancellationToken cancellationToken)
        {
            var thongTinCongTyList = await _thongTinCongTyRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            
            if (thongTinCongTyList == null || !thongTinCongTyList.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công ty nào");
            }
            return thongTinCongTyList.MapToThongTinCongTyDtoList(_mapper);
        }
    }
}
