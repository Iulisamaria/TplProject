using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class PassTypeRepository:IPassType
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public PassTypeRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }
        public void AddPassType(AddPassTypeViewModel pass)
        {

            PassType passType = new PassType()
            { 
                 TypePass=pass.TypePass,
                 Price=pass.Price,
            };
            _DatabaseContext.PassType.Add(passType);
            _DatabaseContext.SaveChanges();

        }
        public async Task<PassTypeDetailsViewModel> Get(int id)
        {
            var pass = await _DatabaseContext.PassType.FindAsync(id);
            if (pass is null)
                throw new Exception();

            PassTypeDetailsViewModel passDetails = new PassTypeDetailsViewModel()
            {
               TypePass=pass.TypePass,
               Price=pass.Price
            };
            return passDetails;
        } 
        public async Task<List<PassType>> GetAll()
        {
            var listPassType = _DatabaseContext.PassType.ToList();
            if (listPassType is null)
                throw new Exception();
            return listPassType;
        }
        public async Task<PassType> Delete(int id)
        {
            var pass = await _DatabaseContext.PassType.FindAsync(id);
            if (pass == null)
                throw new Exception();
            _DatabaseContext.PassType.Remove(pass);
            _DatabaseContext.SaveChanges();
            return pass;
        }
        public async Task Update(BasePassTypeViewModel passType)
        {
            var oldPassType = await _DatabaseContext.PassType.FindAsync(passType.Id);
            oldPassType.Price = passType.Price;
            oldPassType.TypePass = passType.TypePass;

            _DatabaseContext.Update(oldPassType);
            _DatabaseContext.SaveChanges();
        }
    }
}
