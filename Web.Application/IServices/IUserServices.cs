using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Application.IServices
{
    public interface IUserServices //COPIA DE REPOSITORY ES UNA CAPA MÁS DE SEGURIDAD PARA NO CARGA LA BASE
    {   
        IEnumerable<User?> GetUserList();
        User? GetUserById(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool deleteUser(int id);


    }
}
