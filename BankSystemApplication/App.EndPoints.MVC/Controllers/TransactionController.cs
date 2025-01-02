using App.Domain.Core.Contracts.AppService;
using App.Domain.Services.AppService;
using App.Infra.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Controllers
{
	public class TransactionController : Controller
	{
		private readonly ITransactionAppService _transactionAppService;
		private readonly ICardAppService _cardAppService;
		private readonly IUserAppService _userAppService;
		private readonly IVerificationAppService _verificationAppService;

		public TransactionController()
		{
			_transactionAppService = new TransactionAppService();
			_cardAppService = new CardAppService();
			_userAppService = new UserAppService();
			_verificationAppService = new VerificationAppService();
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult TransactionCredentials(string destinationCardNumber, decimal amount)
		{
			var desinationCard = _cardAppService.GetCardByCardNumber(destinationCardNumber);
			if (desinationCard == null)
			{
				TempData["ErrorMessage"] = "Destination Card Number Could Not Be Found";
				return View();
			}
			var destinationAccountInfo = _transactionAppService.GetDistinationInfo(destinationCardNumber);
			var sourceCard = _userAppService.GetUserCard(InMemoryDb.CurrentUser.Id);
			TransactionInfo.Amount = amount;
			TransactionInfo.SourceCardId = sourceCard.Id;
			TransactionInfo.DestinationCardId = desinationCard.Id;
			return View(destinationAccountInfo);

		}

		public IActionResult Verify()
		{
			var code = _verificationAppService.GenerateCode();
			TransactionInfo.VerificationCode = code;
			var verificationCodeGeneratedAt = _verificationAppService.SaveCode(code.ToString());
			TransactionInfo.VerificationCodeGeneratedAt = verificationCodeGeneratedAt;
			//assign the code to transaction
			return View();
		}

		[HttpPost]
		public IActionResult CheckVerificationCode(string inputCode)
		{
			if (int.Parse(inputCode) == TransactionInfo.VerificationCode)
			{
				if (TransactionInfo.VerificationCodeGeneratedAt.AddMinutes(5) > DateTime.Now)
					return RedirectToAction("Transfer");
				else
				{
					TempData["ErrorMessage"] = "Verification Code Expired";
					return View();
				}
			}
			TempData["ErrorMessage"] = "Incorrect Verification Code. Try Again";
			return View("Verify");
		}

		public IActionResult Transfer()
		{
			var result = _transactionAppService.Transfer(TransactionInfo.SourceCardId,
				TransactionInfo.DestinationCardId,
				TransactionInfo.Amount);
			if (result) return View();
			TempData["ErrorMessage"] = "Insufficient Balance";
			return View();
		}

		[HttpPost]
		public IActionResult RedirectToUserPanel()
		{
			return RedirectToAction("UserPanel", "User");
		}
	}
}
