using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public Estado Estado { get; set; }
    }
}
