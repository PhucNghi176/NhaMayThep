using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.NhanVien.GetUser
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, NhanVienDtoLogin>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;

        public LoginQueryHandler(INhanVienRepository repository, IMapper mapper, IChucVuRepository chucVuRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
        }

        public async Task<NhanVienDtoLogin> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _repository.FindAnyAsync(x => x.Email == request.user.Email);

            if (user != null)
            {
                var chucvu = await _chucVuRepository.FindAnyAsync(x => x.ID == user.ChucVuID);

                var samePassword = _repository.VerifyPassword(request.user.Password, user.PasswordHash);
                if (samePassword)
                {

                    return NhanVienDtoLogin.Create(user.Email, user.ID, chucvu.Name);

                }
            }

            throw new NotFoundException($"Email or password was incorrect.");
        }
    }
}
