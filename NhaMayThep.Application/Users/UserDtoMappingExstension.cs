using AutoMapper;

namespace NhaMapThep.Application.Users
{
    public static class UserDtoMappingExstension
    {

        public static UserDto MapToUserDto(this Domain.Entities.User user, IMapper mapper)
        => mapper.Map<UserDto>(user);
    }
}
