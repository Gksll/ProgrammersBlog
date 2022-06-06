using AutoMapper;
using Data.Abstract;
using Entities.Concreate;
using Entities.Concreate.Dtos;
using Services.Abstract;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{

    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{article.Title} adlı makale başarıyla eklenmiştir.");
        }



        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success,
                });
            }
            else
            {
                return new DataResult<ArticleDto>(null, ResultStatus.Error, "Böyle bir makale bulunamadı");
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(null, ResultStatus.Error, "Makaleler bulunamadı");
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive && a.CategoryId == categoryId, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                else
                {
                    return new DataResult<ArticleListDto>(null, ResultStatus.Error, "Makaleler bulunamadı");
                }
            }

            return new DataResult<ArticleListDto>(null, ResultStatus.Error, "Böyle bir kategori bulunamadı");
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(null, ResultStatus.Error, "Makaleler bulunamadı");
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(null, ResultStatus.Error, "Makaleler bulunamadı");
            }
        }
        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(c => c.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => !a.IsDeleted && a.IsActive && a.Id == articleId);
                article.ModifiedByName = modifiedByName;
                article.IsDeleted = true;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} adlı makale başarıyla silinmiştir.");
            }
            else 
            {
                return new Result(ResultStatus.Error,"Böyle bir makale bulunamadı!");
            }


        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(c => c.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => !a.IsDeleted && a.IsActive && a.Id == articleId);
                
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} adlı makale başarıyla veri tabanından silinmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı!");
            }
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} adlı makale başarıyla güncellenmiştir.");
        }
    }
}
