using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LuongSanPhamDto>>
    {
        private readonly ILuongSanPhamRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILuongSanPhamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LuongSanPhamDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var LuongSanPham = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (LuongSanPham == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Lương Sản Phẩm nào.");
            return LuongSanPham.MapToLuongSanPhamDtoList(_mapper).ToList();

        }
    }
}
