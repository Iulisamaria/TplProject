using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface ICard
    {
         Card AddCard() ;
        Task UpdateRoutes(int ticketNumber, decimal cnp);
        Task<DetailsCardViewModels> Get(int id);
    }
}
