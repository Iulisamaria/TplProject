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
        Task AddTickets(int ticketNumber, decimal cnp);
        Task<DetailsCardViewModels> Get(int id);
        Task<GetPassCardViewModels> GetPass(decimal cnp);
        Task<GetTicketsCardViewModels> GetTickets(decimal cnp);

        Task Update(BaseCardViewModels card, decimal cnp);
        Task<Card> Delete(int id);
    }
}
