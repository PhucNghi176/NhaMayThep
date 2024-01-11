using AutoMapper;
using NhaMapThep.Application.Common.Mappings;


namespace NhaMapThep.Application.Users
{
    public class UserDto : IMapFrom<Domain.Entities.User>
    {
        public UserDto()
        {

        }

        public static UserDto Create(string userName, string password)
        {
            return new UserDto
            {
                userName = userName,
                password = password
            };
        }

        public string userName { get; set; }
        public string password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}
