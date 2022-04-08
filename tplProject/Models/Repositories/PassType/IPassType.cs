using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface IPassType
    {
        public void AddPassType(AddPassTypeViewModel pass);
        Task<PassTypeDetailsViewModel> Get(int id);
        Task<List<PassType>> GetAll();

        Task<PassType> Delete(int id);
        Task Update(BasePassTypeViewModel passType);
    }
}
