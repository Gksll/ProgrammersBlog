using Shared.Entities.Abstract;

namespace Entities.Concreate.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }

}
