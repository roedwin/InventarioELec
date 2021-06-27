using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Electrodoméstico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public int IdSucursal { get; set; }
        public int Cantidad { get; set; }
        public Estado Estado { get; set; }
        public virtual List<TipoCategoria> TipoCategoria { get; set; }
        public virtual List<Sucursal> Sucursales { get; set; }
    }
}
