using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.AppService
{
	public interface ICardAppService
	{
		bool ConfirmTransaction(int sourceId, decimal amount, string destinationSource);
		Card GetCardByCardNumber(string cardNumber);
		Card GetCardByUserId(int id);
	}
}
