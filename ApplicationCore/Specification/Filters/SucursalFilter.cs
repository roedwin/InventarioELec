using ApplicationCore.Enum;

namespace ApplicationCore.Specification.Filters
{
    public class SucursalFilter : BaseFilter
    {
        public Estado Estado { get; set; }
        public string Nombre { get; set; }
    }
}
