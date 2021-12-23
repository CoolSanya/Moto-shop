using Moto_shop.Models;

namespace Moto_shop.DAL
{
    public interface IUserRepository : IDisposable
    {
        User RegisterUser(User user);
        User CheckPassword(string email, string password);

    }
}
