using Shared.Entities.Abstract;
using Shared.Utilities.Results.ComplexTypes;

namespace Entities.Concreate.Dtos
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }

        
    }
}
