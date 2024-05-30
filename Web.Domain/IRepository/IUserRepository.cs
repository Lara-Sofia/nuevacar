using Web.Domain.Models;

namespace Web.Infraestructure.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User?> GetUserList();
        User? GetUserById(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool deleteUser(int id);


    }
}
