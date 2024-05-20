using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LuongCongNhat.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LuongCongNhatDto>>
    {
        private readonly ILuongCongNhatRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILuongCongNhatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LuongCongNhatDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var LuongCongNhat = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (LuongCongNhat == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Lương Công Nhật nào.");
            return LuongCongNhat.MapToLuongCongNhatDtoList(_mapper).ToList();
        }
    }
}
