
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Services
{
    public interface ICardService
    {
        void Add(Card newCard);
        Card GetCard(int id);
        Card GetByCardNumber(string cardNumber);
        void UpdateCard(int cardNumberId, Card updatedCard);
        void DeleteCard(int cardNumberId);
        void Save();
    }
}
