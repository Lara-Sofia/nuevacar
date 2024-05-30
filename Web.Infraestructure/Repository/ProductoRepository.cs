using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.IRepository;
using Web.Domain.Models;
using Web.Infraestructure.Context;

namespace Web.Infraestructure.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly WebContext _webContextProduct;
        public ProductoRepository(WebContext webContextProduct)
        {
            _webContextProduct = webContextProduct;
        }

      
        public IEnumerable<Producto?> GetProductList()
        {
            return _webContextProduct.Productos.Where(p => p.Activo).ToList();
        }

        public Producto? GetById(int id)
        {
            return _webContextProduct.Productos.FirstOrDefault(x => x.Id == id && x.Activo);
        }

        public bool CreateProduct(Producto producto)
        {
            _webContextProduct.Productos.Add(producto);
            _webContextProduct.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Producto producto)
        {
            var prod = _webContextProduct.Productos.FirstOrDefault(x => x.Id == producto.Id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Descripcion = producto.Descripcion;
            prod.Stock = producto.Stock;
            prod.PrecioUnitario = producto.PrecioUnitario;

            _webContextProduct.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var prod = _webContextProduct.Productos.FirstOrDefault(x => x.Id == id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Activo = false; //remove lógico no lo elimina enserio
            _webContextProduct.SaveChanges();
            return true;
        }

        public int AddUser(Producto producto)
        {
            _webContextProduct.Productos.Add(producto);
            _webContextProduct.SaveChanges();
            return producto.Id;
        }
    }
}
