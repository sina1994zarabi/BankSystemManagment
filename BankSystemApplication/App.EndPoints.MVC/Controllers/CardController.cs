using App.Domain.Core.Contracts.AppService;
using App.Domain.Services.AppService;
using Microsoft.AspNetCore.Mvc;
using App.Infra.Db;

namespace App.EndPoints.MVC.Controllers
{
	public class CardController : Controller
	{
		private readonly ICardAppService _cardAppService;
		private readonly ITransactionAppService _transactionAppService;

        public CardController(ICardAppService cardAppService,ITransactionAppService transactionAppService)
        {
			_cardAppService = cardAppService;
			_transactionAppService = transactionAppService;
        }

        public IActionResult Index()
		{
			var card = _cardAppService.GetCardByUserId(InMemoryDb.CurrentUser.Id);
			return View(card);
		}
		
		public IActionResult ViewHistory()
		{
			var card = _cardAppService.GetCardByUserId(InMemoryDb.CurrentUser.Id);
			var transactions = _transactionAppService.GetTransactionReport().
				Where(x=>x.SourceCardNumber == card.CardNumber);
			return View(transactions);
		}
	}
}
