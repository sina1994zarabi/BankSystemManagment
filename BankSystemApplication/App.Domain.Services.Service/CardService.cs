using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Infra.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Add(Card newCard)
        {
            _cardRepository.Add(newCard);
        }

        public void DeleteCard(int cardNumberId)
        {
            _cardRepository.DeleteCard(cardNumberId);
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _cardRepository.GetByCardNumber(cardNumber);
        }

        public Card GetCard(int id)
        {
            return _cardRepository.GetCard(id);
        }

        public void UpdateCard(int cardNumberId, Card updatedCard)
        {
            _cardRepository.UpdateCard(cardNumberId,updatedCard);
        }

        public void Save()
        {
            _cardRepository.Save();
        }
    }
}
