using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.NhanVien.GetUser
{
    public class GetNhanVienQueryHandler : IRequestHandler<GetNhanVienQuery, NhanVienDto>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;

        public GetNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NhanVienDto> Handle(GetNhanVienQuery request, CancellationToken cancellationToken)
        {

            var user = await _repository.FindAsync(x => x.Email == request.Email);
            if (user != null)
            {
                var samePassword = _repository.VerifyPassword(request.Password, user.PasswordHash);
                if (samePassword)
                {
                    return user.MapToNhanVienDto(_mapper);
                }
            }
            throw new NotFoundException($"Email or password was incorrect.");
        }
    }
}
