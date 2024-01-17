using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.NhanVien.GetUser
{
    public class GetNhanVienQueryHandler : IRequestHandler<GetNhanVienQuery, NhanVienDto>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        private readonly IChucVuRepository _chucVuRepository;

        public GetNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper, IChucVuRepository chucVuRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _chucVuRepository = chucVuRepository;
        }

        public async Task<NhanVienDto> Handle(GetNhanVienQuery request, CancellationToken cancellationToken)
        {

            var user = await _repository.FindAsync(x => x.Email == request.user.UserName);
            
            if (user != null)
            {
                var chucvu = await _chucVuRepository.FindAsync(x => x.ID == user.ChucVuID);
                //user.ChucVu = chucvu.Name.ToString();
                var samePassword = _repository.VerifyPassword(request.user.Password, user.PasswordHash);
                if (samePassword)
                {
                    user.MapToNhanVienDto(_mapper);
                }
            }
            throw new NotFoundException($"Email or password was incorrect.");
        }
    }
}
