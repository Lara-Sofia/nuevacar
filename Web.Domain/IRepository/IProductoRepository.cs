
using Web.Domain.Models;

namespace Web.Domain.IRepository
{
    public interface IProductoRepository
    {
        IEnumerable<Producto?> GetProductList();
        Producto? GetById(int id);
        bool CreateProduct(Producto producto);
        bool UpdateProduct(Producto producto);
        bool DeleteProduct(int id);

        int AddUser(Producto producto);
    }
}
