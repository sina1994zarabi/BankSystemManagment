using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Domain.Services.Service;
using App.Infra.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppService
{
	public class CardAppService : ICardAppService
	{
		private readonly ICardService _cardService;
		private readonly IUserService _userService;

        public CardAppService()
        {
			_cardService = new CardService();
			_userService = new UserService();
        }

		public bool ConfirmTransaction(int sourceId, decimal amount, string destinationNumber)
		{
			var sourceCard = _cardService.GetCard(sourceId);
			var destinationCard = _cardService.GetByCardNumber(destinationNumber);
			if (amount  < sourceCard.Balance)
			{
				if (destinationNumber == destinationCard.CardNumber)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public Card GetCardByCardNumber(string  cardNumber)
		{
			return _cardService.GetByCardNumber(cardNumber);
		}

		public Card GetCardByUserId(int id)
		{
			return _userService.GetById(id).Cards.Single();
		}
	}
}
