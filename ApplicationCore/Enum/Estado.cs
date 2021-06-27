using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Enum
{
    public enum Estado
    {
        [Display(Name = "Habilitado")]
        Habilitado,
        [Display(Name = "Deshabilidato")]
        Deshabilidato
    }
}
