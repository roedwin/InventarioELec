using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class SucursalValidator : AbstractValidator<Sucursal>
    {
        public SucursalValidator()
        {
            RuleFor(x => x.IdSucursal).NotNull();

            RuleFor(x => x.Nombre).NotNull().WithMessage("Nombre es requerido").Length(3, 30).WithMessage("El Nombre debe contener entre 3 y 30 caracteres");

            RuleFor(x => x.Direccion).NotNull().WithMessage("Debe incluir la direccion");

            RuleFor(x => x.Telefono).NotNull().Matches(@"^\d{4}-\d{4}$").WithMessage("El número de telefono debe de tener formato correcto");

            RuleFor(x => x.Estado).IsInEnum().WithMessage("Ingrese un Genero valido");
        }
    }
}
