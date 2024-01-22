using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinCongTy.GetThongTinCongTyById
{
    public class GetThongTinCongTyByIdQueryHandler : IRequestHandler<GetThongTinCongTyByIdQuery, ThongTinCongTyDto>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly IMapper _mapper;

        public GetThongTinCongTyByIdQueryHandler(IThongTinCongTyRepository thongTinCongTyRepository, IMapper mapper)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _mapper = mapper;
        }

        public async Task<ThongTinCongTyDto> Handle(GetThongTinCongTyByIdQuery request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository.FindAsync(t => t.MaDoanhNghiep == request.MaDoanhNghiep, cancellationToken);

            if (thongTinCongTy is null)
                throw new NotFoundException($"Khong tim thay MaDoanhNghiep {request.MaDoanhNghiep}");

            return thongTinCongTy.MapToThongTinCongTyDto(_mapper);
        }
    }
}