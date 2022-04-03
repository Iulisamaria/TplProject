﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<DetailsPassViewModel> Get(int id)
        {

            var pass = _databaseContext.Pass.Find(id);
            if (pass == null)
            {
                throw new Exception();
            }
            DetailsPassViewModel passDetails = new DetailsPassViewModel()
            {
                EndDate=pass.EndDate,
                StartDate=pass.StartDate,
                 IdType=pass.IdType
            };
            return passDetails;

        }
        public async Task Update(BasePassViewModel pass)
        {
            var oldPass = await _databaseContext.Pass.FindAsync(pass.Id);
            oldPass.IdType = pass.IdType;
            oldPass.StartDate = pass.StartDate;
            oldPass.EndDate = pass.EndDate;
            _databaseContext.Update(oldPass);
            _databaseContext.SaveChanges();
        }
        public async Task<Pass> Delete(int id)
        {
            var pass = await _databaseContext.Pass.FindAsync(id);
            if (pass == null)
                throw new Exception();
            _databaseContext.Pass.Remove(pass);
            _databaseContext.SaveChanges();

            return pass;
        }
    }
}
