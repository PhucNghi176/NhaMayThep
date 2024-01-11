namespace NhaMayThep.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string userName, IList<string> roles = null);
    }
}
