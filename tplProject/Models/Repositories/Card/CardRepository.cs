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
        public async Task<GetPassCardViewModels> GetPass(decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                                         .FirstOrDefaultAsync(i => i.Cnp == cnp);
            var card = await _databaseContext.Card.Include(i => i.Pass).FirstOrDefaultAsync(i => i.Id == user.IdCard);
            var pass = await _databaseContext.Pass.Include(i => i.IdTypeNavigation).FirstOrDefaultAsync(i => i.Id == card.PassId);
            if (user == null || card==null || pass==null)
            {
                throw new Exception();
            }
            GetPassCardViewModels cardDetails = new GetPassCardViewModels()
            {
                PassName = pass.IdTypeNavigation.TypePass
            };
            return cardDetails;
        }
        public async Task<GetTicketsCardViewModels> GetTickets(decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                                         .FirstOrDefaultAsync(i => i.Cnp == cnp);
            var card = await _databaseContext.Card.Include(i => i.Pass).FirstOrDefaultAsync(i => i.Id == user.IdCard);
            if (user == null || card==null)
            {
                throw new Exception();
            }
            GetTicketsCardViewModels cardDetails = new GetTicketsCardViewModels()
            {
                 Routes=card.Routes
            };
            return cardDetails;
        }
        //update card table  when buys new pass
        public async Task Update(BaseCardViewModels card,decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                              .FirstOrDefaultAsync(i => i.Cnp == cnp);
            if (user == null)
            {
                throw new Exception();
            }
            var oldCard = await _databaseContext.Card.FindAsync(card.Id);
            oldCard.PassId = card.PassId;
            _databaseContext.Update(oldCard);
            _databaseContext.SaveChanges();
        }
        //Update card table when user buys ticket.. AddTickets
        public async Task AddTickets(int ticketNumber, decimal cnp)
        {
            var user = await _databaseContext.User.Include(i => i.IdCardNavigation)
                  .FirstOrDefaultAsync(i => i.Cnp == cnp);
              var pass = await _databaseContext.Pass.FindAsync(user.IdCardNavigation.PassId);

            if (user == null)
            {
                throw new Exception();
            }
            //if (pass != null && pass.EndDate > DateTime.Now)
            //{
            //    throw new Exception();
            //}
            if (user.IdCardNavigation.Routes == null)
                user.IdCardNavigation.Routes = 0;
            user.IdCardNavigation.Routes += ticketNumber;
            _databaseContext.Update(user.IdCardNavigation);
            _databaseContext.SaveChanges();

        }
        public async Task<Card> Delete(int id)
        {
            var card = await _databaseContext.Card.FindAsync(id);
            if (card == null)
                throw new Exception();
            _databaseContext.Card.Remove(card);
            _databaseContext.SaveChanges();

            return card;
        }
    }
}
