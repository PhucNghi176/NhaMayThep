using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQueryHandler : IRequestHandler<GetLuongCongNhatByIdQuery, LuongCongNhatDto>
    {
        private readonly ILuongCongNhatRepository _repository;
        private readonly IMapper _mapper;


        public GetLuongCongNhatByIdQueryHandler(ILuongCongNhatRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LuongCongNhatDto> Handle(GetLuongCongNhatByIdQuery request, CancellationToken cancellationToken)
        {
            var luongCongNhat = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (luongCongNhat == null)
                throw new NotFoundException($"không tìm thấy lương công nhật vơi ID : {request.ID} hoặc đã bị xóa.");

            return luongCongNhat.MapToLuongCongNhatDto(_mapper);
        }

    }
}
