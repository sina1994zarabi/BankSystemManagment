using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.Core.Contracts.Repository
{
    public interface ICardRepository
    {
        void Add(Card newCard);
        Card GetCard(int id);
        Card GetByCardNumber(string cardNumber);
        void UpdateCard(int cardNumberId, Card updatedCard);
        void DeleteCard(int cardNumberId);
        void Save();
    }
}
