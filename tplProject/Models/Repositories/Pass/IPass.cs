using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface IPass
    {
        Task AddPass(AddPassViewModel pass, decimal cnp);
        Task<Pass> Delete(int id);
        Task Update(BasePassViewModel pass);
        Task<DetailsPassViewModel> Get(int id);


    }
}
