using TestAgileSoft.Domain.Entities;

namespace TestAgileSoft.Domain.Ports
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
