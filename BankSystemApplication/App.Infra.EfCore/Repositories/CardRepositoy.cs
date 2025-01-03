

using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;

namespace App.Infra.EfCore.Repositories
{
    public class CardRepositoy : ICardRepository
    {
        private readonly AppDbContext _dbContext;


        public CardRepositoy(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Card newCard)
        {
            _dbContext.Cards.Add(newCard);
            _dbContext.SaveChanges();
        }

        public Card GetCard(int id)
        {
            return _dbContext.Cards.FirstOrDefault(c => c.Id == id);
        }




        public void UpdateCard(int cardNumberId, Card updatedCard)
        {
            var cardToUpdate = _dbContext.Cards.FirstOrDefault(c => c.Id == cardNumberId);
            if (cardToUpdate != null)
            {
                cardToUpdate.CardNumber = updatedCard.CardNumber;
                cardToUpdate.Balance = updatedCard.Balance;
                cardToUpdate.IsActive = updatedCard.IsActive;
            }
        }

        public void DeleteCard(int id)
        {
            var cardToDelete = _dbContext.Cards.FirstOrDefault(c => c.Id == id);
            _dbContext.Remove(cardToDelete);
            _dbContext.SaveChanges();
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _dbContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void Save() { _dbContext.SaveChanges(); }

    }
}
