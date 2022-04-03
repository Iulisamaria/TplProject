using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class LostItemsRepository : ILostItems
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public LostItemsRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        public  void AddLostItems(AddLoseItemsViewModel loseItems)
        {

            LostItems addLostItems = new LostItems()
            {   
                Info = loseItems.Info,
                NrCrt = loseItems.NrCrt
            };
             _DatabaseContext.LostItems.Add(addLostItems);
             _DatabaseContext.SaveChanges();

        }
        public async Task<LostItemsDetailsViewModel> Get(int id)
        {

            var lostItems = _DatabaseContext.LostItems.Find(id);
            if (lostItems == null)
            {
                throw new Exception();
            }
            LostItemsDetailsViewModel lostItemsDetails = new LostItemsDetailsViewModel()
            {
                Id = lostItems.Id,
                Info = lostItems.Info,
                NrCrt = lostItems.NrCrt
            };
            return lostItemsDetails;

        }
        public async Task Update(BaseLostItemsViewModel lostItems )
        {
            LostItemsDetailsViewModel lostItemsDetails = new LostItemsDetailsViewModel()
            {
                Id = lostItems.Id,
                Info = lostItems.Info,
                NrCrt = lostItems.NrCrt
            };
            _DatabaseContext.Update(lostItems);
            _DatabaseContext.SaveChanges();
        }

    }
}
