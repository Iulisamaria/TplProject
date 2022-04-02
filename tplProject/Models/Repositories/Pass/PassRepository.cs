using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class PassRepository:IPass
    {
        public readonly tpl_databaseContext _databaseContext;
        public PassRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task AddPass(AddPassViewModel pass)
        {

            Pass addPass = new Pass()
            {
                StartDate =pass.StartDate,
                EndDate = pass.EndDate,
            };
            _databaseContext.Pass.Add(addPass);
            _databaseContext.SaveChanges();
        }

    }
}
