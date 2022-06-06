using Shared.Entities.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.Dtos
{
    public class ArticleDto:DtoGetBase
    {
       
        public Article Article { get; set; }


    }
}
