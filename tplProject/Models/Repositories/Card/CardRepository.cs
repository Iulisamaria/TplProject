using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.Models.Repositories;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class CardRepository : ICard
    {
        public readonly tpl_databaseContext _databaseContext;
        public CardRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Card AddCard()
        {
            Card addCard = new Card();
            _databaseContext.Card.Add(addCard);
            _databaseContext.SaveChanges();
            return addCard;
        }
        public async Task<DetailsCardViewModels> Get(int id)
        {
            var card = await _databaseContext.Card.FindAsync(id);
            if (card is null)
                throw new Exception();

            DetailsCardViewModels cardDetails = new DetailsCardViewModels()
            {
                 PassId=card.PassId,
                 Routes=card.Routes,
            };
            return cardDetails;
        }
        //update card table  when buys pass
        public async Task Update(BaseCardViewModels card)
        {

            BaseCardViewModels cardUpdate = new BaseCardViewModels()
            {
            };
            _databaseContext.Update(cardUpdate);
            _databaseContext.SaveChanges();
        }
        //Update card table when user buys ticket
        public async Task UpdateRoutes(int ticketNumber, decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                  .FirstOrDefaultAsync(i => i.Cnp == cnp);
            var pass = await _databaseContext.Pass.FindAsync(user.IdCardNavigation.PassId);

            if (user == null)
            {
                throw new Exception();
            }
            if (pass != null && pass.EndDate > DateTime.Now)
            {
                throw new Exception();
            }
            if (user.IdCardNavigation.Routes == null)
                user.IdCardNavigation.Routes = 0;
            user.IdCardNavigation.Routes += ticketNumber;
            _databaseContext.Update(user.IdCardNavigation);
            _databaseContext.SaveChanges();

        }
    }
}
