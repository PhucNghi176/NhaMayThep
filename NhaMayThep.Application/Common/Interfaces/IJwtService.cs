namespace NhaMayThep.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string email, string ID, string roles);
    }
}
