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
    public class TipoCategoria
    {   
        public int IdCategoria { get; set; }
        public String Nombre { get; set; }
        public Estado Estado { get; set; }
    }
}
