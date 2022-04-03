using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class PassRepository : IPass
    {
        public readonly tpl_databaseContext _databaseContext;
        public PassRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task AddPass(AddPassViewModel pass, decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                     .FirstOrDefaultAsync(i => i.Cnp == cnp);
            if (user == null)
                throw new Exception("User not found");

            Pass addPass = new Pass()
            {
                StartDate = pass.StartDate,
                EndDate = pass.EndDate,
                IdType = pass.IdType,
            };

            user.IdCardNavigation.Pass = addPass;
            _databaseContext.Pass.Add(addPass);
            _databaseContext.Card.Update(user.IdCardNavigation);
            _databaseContext.SaveChanges();
        }

    }
}
