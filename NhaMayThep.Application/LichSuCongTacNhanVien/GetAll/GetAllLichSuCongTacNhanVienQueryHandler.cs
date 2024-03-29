using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiCongTac;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetAll
{
    public class GetAllLichSuCongTacNhanVienQueryHandler : IRequestHandler<GetAllLichSuCongTacNhanVienQuery, List<LichSuCongTacNhanVienDto>>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public GetAllLichSuCongTacNhanVienQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<List<LichSuCongTacNhanVienDto>> Handle(GetAllLichSuCongTacNhanVienQuery request, CancellationToken cancellationToken)
        {
            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("Danh Sách Rỗng");
            }
            foreach(var item in list)
            {
                item.LoaiCongTac.MapToLoaiCongTacDto(_mapper);
            }
            return list.MapToLichSuCongTacNhanVienDtoList(_mapper);
        }
    }
}
