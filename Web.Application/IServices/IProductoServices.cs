using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Application.IServices
{
    public interface IProductoServices
    {
        //se supone que aca ban los métodos usando los dtos
        IEnumerable<Producto?> GetProductList();
        Producto? GetById(int id);
        bool CreateProduct(Producto producto);
        bool UpdateProduct(Producto producto);
        bool DeleteProduct(int id);

        int AddUser(DtoProducto DtoProducto);
    }
}
