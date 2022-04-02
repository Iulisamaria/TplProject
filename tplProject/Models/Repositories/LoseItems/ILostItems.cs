using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface ILostItems
    {
        public void AddLostItems(AddLoseItemsViewModel loseItems);
        Task<LostItemsDetailsViewModel> Get(int id);
        Task Update(BaseLostItemsViewModel lostItems);
    }
}
