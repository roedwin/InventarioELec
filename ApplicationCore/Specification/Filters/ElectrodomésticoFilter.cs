
using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
    public class ElectrodomésticoFilter : BaseFilter
    {
        public Estado Estado { get; set; }
        public string Nombre { get; set; }
    }
}
