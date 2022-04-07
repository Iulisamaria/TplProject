using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class BusRepository : IBus
    {
        public readonly tpl_databaseContext _DatabaseContext;
        public BusRepository(tpl_databaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        public void AddBus(AddBussViewModel bus)
        {

            Bus busAdd = new Bus()
            {
                Name = bus.Name
            };
            _DatabaseContext.Bus.Add(busAdd);
            _DatabaseContext.SaveChanges();
        }
        public async Task<List<Bus>> GetAll()
        {
            var allBus = _DatabaseContext.Bus.ToList();
            if (allBus == null)
                throw new Exception();
            return allBus;
        }

        public async Task<BaseBusViewModel> Get(int id)
        {

            var bus =await  _DatabaseContext.Bus.FindAsync(id);
            if (bus == null)
            {
                throw new Exception();
            }
            BaseBusViewModel busDetails = new BaseBusViewModel()
            {
                Name=bus.Name,
                 Id=bus.Id
                 
            };
            return busDetails;

        }
        public async Task Update(BaseBusViewModel bus)
        {
            var oldBus = await _DatabaseContext.Bus.FindAsync(bus.Id);
            if (oldBus == null)
                throw new Exception();
            oldBus.Name = bus.Name;
             _DatabaseContext.Update(oldBus);
            _DatabaseContext.SaveChanges();
        }
        public async Task<Bus> Delete(int id)
        {
            var bus = await _DatabaseContext.Bus.FindAsync(id);
            if (bus == null)
                throw new Exception();
            _DatabaseContext.Bus.Remove(bus);
            _DatabaseContext.SaveChanges();

            return bus;
        }
    }
}
    


