using AutoMapper;
using MediatR;
using NhaMapThep.Application.Users;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMapThep.Application.Authenticate.Login
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(
                u => u.Username == request.userName && u.Password == request.password,
                cancellationToken: cancellationToken
                );
            if (user == null)
                throw new NotFoundException($"Could not find UserName '{request.userName}'");
            return user.MapToUserDto(_mapper);
        }
    }
}
