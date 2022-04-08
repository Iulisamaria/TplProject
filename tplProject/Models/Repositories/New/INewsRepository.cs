using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories.New
{
    public interface INewsRepository
    {
        public void Add(AddNewsViewModel news);
        Task<NewsDetailsViewModel> Get(int id);
        Task<List<News>> GetAll();
        Task Update(UpdateNewsViewModel news);
        Task<News> Delete(int id);

    }
}
