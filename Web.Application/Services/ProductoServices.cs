using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.IServices;
using Web.Domain.IRepository;
using Web.Domain.Models;

namespace Web.Application.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository _repository;
        public ProductoServices(IProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Producto?> GetProductList()
        {
            return _repository.GetProductList();
        }

        public Producto? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool CreateProduct(Producto producto)
        {
            if (_repository.GetById(producto.Id) != null)
            {
                return false;
            }

            return _repository.CreateProduct(producto);
        }

        public bool UpdateProduct(Producto producto)
        {
            return _repository.UpdateProduct(producto);
        }

        public bool DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }

        public int AddUser(DtoProducto DtoProducto)
        {
            var producto = new Producto()
            {
                Descripcion = DtoProducto.Descripcion,
                PrecioUnitario = DtoProducto.PrecioUnitario,
                Stock = DtoProducto.Stock,
            };
            return _repository.AddUser(producto);
        }
    }
}
