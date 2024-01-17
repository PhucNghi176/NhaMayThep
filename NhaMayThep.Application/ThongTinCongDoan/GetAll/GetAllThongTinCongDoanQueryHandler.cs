using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAll
{
    public class GetAllThongTinCongDoanQueryHandler : IRequestHandler<GetAllThongTinCongDoanQuery, List<ThongTinCongDoanDto>>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        public GetAllThongTinCongDoanQueryHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinCongDoanDto>> Handle(GetAllThongTinCongDoanQuery request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var thongtincongdoans = await _thongtinCongDoanRepository
                .FindAllAsync(x=> !x.NgayXoa.HasValue && x.NguoiXoaID == null,cancellationToken);
            if(thongtincongdoans == null || !thongtincongdoans.Any())
=======
            var thongtincongdoans = await _thongtinCongDoanRepository.FindAllAsync(x => x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (thongtincongdoans == null || !thongtincongdoans.Any())
>>>>>>> origin/main
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công đoàn nào");
            }
            return thongtincongdoans.MapToThongTinCongDoanDtoList(_mapper);
        }
    }
}
