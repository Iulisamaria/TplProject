using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models.Repositories.Station;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class StationReposiroty:IStation
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public StationReposiroty(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        public void AddStation(AddStationViewModel station)
        {

            Stations addStation = new Stations()
            {
               Nume=station.Nume,
            };
            _DatabaseContext.Stations.Add(addStation);
            _DatabaseContext.SaveChanges();

        }
        public async Task<DetailsStationViewModel> Get(int id)
        {

            var station = _DatabaseContext.Stations.Find(id);
            if (station == null)
            {
                throw new Exception();
            }
            DetailsStationViewModel stationDetails = new DetailsStationViewModel()
            {
                Nume=station.Nume,
                Id=station.Id
            };
            return stationDetails;

        }
        public async Task Update(BaseStationViewModel station)
        {
            var oldstation = await _DatabaseContext.Stations.FindAsync(station.Id);
            oldstation.Nume = station.Nume;
            _DatabaseContext.Update(oldstation);
            _DatabaseContext.SaveChanges();
        }
        public async Task<Stations> Delete(int id)
        {
            var station = await _DatabaseContext.Stations.FindAsync(id);
            if (station == null)
                throw new Exception();
            _DatabaseContext.Stations.Remove(station);
            _DatabaseContext.SaveChanges();

            return station;
        }
    }
}
