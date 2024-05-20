using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQueryHandler : IRequestHandler<GetAllKhaiBaoTangLuongQuery, List<KhaiBaoTangLuongDto>>
    {
        private readonly IKhaiBaoTangLuongRepository _repository;
        private readonly IMapper _mapper;
        public GetAllKhaiBaoTangLuongQueryHandler(IKhaiBaoTangLuongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetAllKhaiBaoTangLuongQueryHandler() { }
        public async Task<List<KhaiBaoTangLuongDto>> Handle(GetAllKhaiBaoTangLuongQuery request, CancellationToken cancellationToken)
        {
            var KhaiBaoTangLuong = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (KhaiBaoTangLuong == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Khai Báo Tăng Lương nào.");
            return KhaiBaoTangLuong.MapToKhaiBaoTangLuongDtoList(_mapper).ToList();
        }
    }
}