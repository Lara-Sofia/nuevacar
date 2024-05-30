using Microsoft.EntityFrameworkCore;
using Web.Domain.Models;
using Web.Infraestructure.Context;
using Web.Infraestructure.IRepository;

namespace Web.Infraestructure.Repository
{
    public class UserRepository : IUserRepository

        //se inyecta el contexto porque funciona como una clase abstracta
    {

        private readonly WebContext _WebContext;
        public UserRepository(WebContext WebContext)
        {
            _WebContext = WebContext;//creamos nuestra var
        }

       

        public bool CreateUser(User user)
        {
            _WebContext.Users.Add(user);
            _WebContext.SaveChanges();
            return true;
        }

        public bool deleteUser(int id)
        {
            var user = _WebContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return false;
            }
            _WebContext.Remove(user); //lo borra de verdad 
            _WebContext.SaveChanges();
            return true;
        }

        public User? GetUserById(int id)
        {
            return _WebContext.Users.FirstOrDefault(x =>x.Id == id);
        }

        public IEnumerable<User?> GetUserList()
        {
            return _WebContext.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            var u = _WebContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (u == null)
            {
                return false;
            }

            u.Name = user.Name;
            u.Email = user.Email;
            _WebContext.SaveChanges();
            return true;
        }
    }
}
