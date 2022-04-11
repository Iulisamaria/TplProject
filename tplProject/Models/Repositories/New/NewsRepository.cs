using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories.New
{
    public class NewsRepository : INewsRepository
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public NewsRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        public void Add(AddNewsViewModel news)
        {

            News addNew = new News()
            {
                Name = news.Name,
                Content = news.Content,
                DateStart=news.DateStart
            
            };
            _DatabaseContext.News.Add(addNew);
            _DatabaseContext.SaveChanges();

        }
        public async Task<NewsDetailsViewModel> Get(int id)
        {

            var news = await _DatabaseContext.News.FindAsync(id);
            if (news == null)
            {
                throw new Exception();
            }
            NewsDetailsViewModel newsDetails = new NewsDetailsViewModel()
            {
                 Name=news.Name,
                 Content=news.Content
            };
            return newsDetails;

        }
        public async Task<List<News>> GetAll()
        {
            var news = _DatabaseContext.News.ToList();
            if (news == null)
            {
                throw new Exception();
            }

            return news;
        }
        public async Task Update(UpdateNewsViewModel news)
        {
            var oldNews = await _DatabaseContext.News.FindAsync(news.Id);
            oldNews.Name = news.Name;
            oldNews.Content = news.Content;
            _DatabaseContext.Update(oldNews);
            _DatabaseContext.SaveChanges();
        }
        public async Task<News> Delete(int id)
        {
            var news = await _DatabaseContext.News.FindAsync(id);
            if (news == null)
                throw new Exception();
            _DatabaseContext.News.Remove(news);
            _DatabaseContext.SaveChanges();

            return news;
        }
    }
}
