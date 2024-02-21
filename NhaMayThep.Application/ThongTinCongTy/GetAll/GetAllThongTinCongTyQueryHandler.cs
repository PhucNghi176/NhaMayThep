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
            var thongTinCongTy = await _thongTinCongTyRepository.FindAllAsync(x => !x.NgayXoa.HasValue && x.NguoiXoaID == null, cancellationToken);
            
            if (thongTinCongTy == null || !thongTinCongTy.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công ty nào");
            }
            return thongTinCongTy.MapToThongTinCongTyDtoList(_mapper);
        }
    }
}
