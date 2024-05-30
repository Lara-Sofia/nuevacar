using Web.Application.IServices;
using Web.Domain.Models;
using Web.Infraestructure.IRepository;
//using Web.Infrae LOS IREPOSITORYS VAN EN APP O DOMAIN no se referencia a la infra 

namespace Web.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public bool CreateUser(User user)
        {
            if (_userRepository.GetUserById(user.Id) != null)
            {
                return false;
            }

            return _userRepository.CreateUser(user);

        }

        public bool deleteUser(int id)
        {
            return _userRepository.deleteUser(id);
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public IEnumerable<User?> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }

 
}
