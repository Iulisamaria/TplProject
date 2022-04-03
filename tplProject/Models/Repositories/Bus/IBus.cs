using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface IBus
    {
         Task<Bus> Delete(int id);
         Task Update(BaseBusViewModel bus);
         Task<BaseBusViewModel> Get(int id);
        public void AddBus(AddBussViewModel bus);

    }
}
