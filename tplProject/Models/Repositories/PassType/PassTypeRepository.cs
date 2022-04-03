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


    }
}
