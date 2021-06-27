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
    public class ElectrodomésticoSpec : Specification<Electrodoméstico>
    {
        public ElectrodomésticoSpec(ElectrodomésticoFilter filter)
        {
            Query.OrderBy(x => x.Nombre).ThenByDescending(x => x.Id);

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

            if (!string.IsNullOrEmpty(filter.Nombre))
                Query.Search(x => x.Nombre, "%" + filter.Nombre + "%");
        }
    }
}

