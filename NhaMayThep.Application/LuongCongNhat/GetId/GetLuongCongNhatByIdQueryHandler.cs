using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LuongCongNhat.GetId;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQueryHandler : IRequestHandler<GetLuongCongNhatByIDQuery, LuongCongNhatDto>
    {
        private readonly ILuongCongNhatRepository _repository;
        private readonly IMapper _mapper;


        public GetLuongCongNhatByIdQueryHandler(ILuongCongNhatRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LuongCongNhatDto> Handle(GetLuongCongNhatByIDQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAsync(x => x.ID == request.ID, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LuongCongNhat Does not Exist");

            }
            if (lnp.NgayXoa != null)
            {
                throw new NotFoundException("LuongCongNhat Is Deleted");
            }

            return lnp.MapToLuongCongNhatDto(_mapper);
        }

    }
}
