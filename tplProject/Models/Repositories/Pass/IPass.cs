using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    interface IPass
    {
        Task AddPass(AddPassViewModel pass);
    }
}
