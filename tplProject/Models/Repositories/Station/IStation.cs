using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories.Station
{
   public  interface IStation
    {
        public void AddStation(AddStationViewModel station);
        Task<DetailsStationViewModel> Get(int id);
        Task Update(BaseStationViewModel station);
        Task<Stations> Delete(int id);
    }
}
