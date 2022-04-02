using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.Models.Repositories;

namespace tplProject.Models.Repositories
{
    public class CardRepository : ICard
    {
        public readonly tpl_databaseContext _databaseContext;
        public CardRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public  Card AddCard()
        {

            Card addCard = new Card();
            _databaseContext.Card.Add(addCard);
            _databaseContext.SaveChanges();
            return addCard;

        }
    }
}
