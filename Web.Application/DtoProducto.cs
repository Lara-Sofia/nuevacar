using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application
{
    public  class DtoProducto
    {
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public int? Stock { get; set; }
        public bool Activo { get; set; }
    }
}
