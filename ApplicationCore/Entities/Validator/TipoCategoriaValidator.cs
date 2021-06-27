using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class TipoCategoriaValidator : AbstractValidator<TipoCategoria>
    {
        public TipoCategoriaValidator()
        {
            RuleFor(x => x.IdCategoria).NotNull();

            RuleFor(x => x.Nombre).NotNull().WithMessage("Nombre es requerido")
           .Length(3, 30).WithMessage("El Nombre debe contener entre 3 y 30 caracteres");

            RuleFor(x => x.Estado).IsInEnum().WithMessage("Ingrese un Genero valido");
        }
    }
}
