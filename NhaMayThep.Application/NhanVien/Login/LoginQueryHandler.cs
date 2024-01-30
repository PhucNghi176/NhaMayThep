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

<<<<<<< HEAD:NhaMayThep.Application/NhanVien/Authenticate/LoginQueryHandler.cs
<<<<<<< HEAD:NhaMayThep.Application/NhanVien/Login/LoginQueryHandler.cs
=======
>>>>>>> be09a28ed202255464bd80373d0bfcd3c3a08c08:NhaMayThep.Application/NhanVien/Login/LoginQueryHandler.cs
            var user = await _repository.FindAnyAsync(x => x.Email == request.user.Email);

            if (user != null)
            {
                var chucvu = await _chucVuRepository.FindAnyAsync(x => x.ID == user.ChucVuID);
<<<<<<< HEAD:NhaMayThep.Application/NhanVien/Authenticate/LoginQueryHandler.cs
=======
            var user = await _repository.FindAsync(x => x.Email == request.user.Email && x.NgayXoa == null);
            if (user == null)
            {
                throw new NotFoundException($"Không tìm thấy nhân viên với email - {request.user.Email}");
            }

            if (user != null)
            {
                var chucvu = await _chucVuRepository.FindAsync(x => x.ID == user.ChucVuID && x.NgayXoa == null);
                if (chucvu == null)
                {
                    throw new NotFoundException($"Không tìm thấy nhân viên với chức vụ - {request.user.Email}");
                }
>>>>>>> 5d9b056a84cd2b73b3ff579895b75f4a5b0febe6:NhaMayThep.Application/NhanVien/Authenticate/LoginQueryHandler.cs
=======
>>>>>>> be09a28ed202255464bd80373d0bfcd3c3a08c08:NhaMayThep.Application/NhanVien/Login/LoginQueryHandler.cs

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
