using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
    public class TipoCategoriaSpec : Specification<TipoCategoria>
    {
        public TipoCategoriaSpec(TipoCategoriaFilter filter)
        {
            Query.OrderBy(x => x.Nombre).ThenByDescending(x => x.IdCategoria);

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

            if (!string.IsNullOrEmpty(filter.Nombre))
                Query.Search(x => x.Nombre, "%" + filter.Nombre + "%");
        }
    }
}
