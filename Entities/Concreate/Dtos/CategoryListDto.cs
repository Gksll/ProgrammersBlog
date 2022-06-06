using Shared.Entities.Abstract;

namespace Entities.Concreate.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }

}
