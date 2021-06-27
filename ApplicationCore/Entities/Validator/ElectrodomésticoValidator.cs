using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class ElectrodomésticoValidator : AbstractValidator<Electrodoméstico>
    {
        public ElectrodomésticoValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.Nombre).NotNull().WithMessage("Nombre es requerido")
            .Length(5, 12).WithMessage("El nombre debe tener entre 5 y 20 caracteres");

            RuleFor(x => x.IdCategoria).NotNull().WithMessage("Categoria es requerida");

            RuleFor(x => x.IdSucursal).NotNull().WithMessage("Categoria es requerida");

            RuleFor(x => x.Cantidad).NotNull().WithMessage("La cantidad es requerida");

            RuleFor(x => x.Estado).IsInEnum().WithMessage("Ingrese un Estado valido");

        }
    }
}
