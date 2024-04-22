using Core.Entities;

namespace Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Descriptionapp { get; set; }
        public Double Price { get; set; }
        public int numberunits { get; set; }
    }
}
