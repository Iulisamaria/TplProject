using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface ILostItems
    {
        public void AddLostItems(AddLostItemsViewModel lostItems);
        Task<LostItemsDetailsViewModel> Get(int id);
        Task<List<LostItems>> GetAll();
        Task Update(BaseLostItemsViewModel lostItems);
        Task<LostItems> Delete(int id);
    }
}
