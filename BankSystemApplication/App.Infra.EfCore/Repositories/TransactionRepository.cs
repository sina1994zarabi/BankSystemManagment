
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.EfCore.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly AppDbContext _dbContext;

        public TransactionRepository(AppDbContext dbContext)
        {
			_dbContext = dbContext;
        }

        public void Add(Transaction transaction)
		{
			_dbContext.Transactions.Add(transaction);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var transactionsToDelete = _dbContext.Transactions.Where(t => t.Id == id);
			_dbContext.RemoveRange(transactionsToDelete);
			_dbContext.SaveChanges();
		}


		public List<TransactionWithCardDto> GetAllTransaction()
		{
			return _dbContext.Transactions.Include(t => t.SourceCard).
				Include(t => t.DestinationCard).
				Select(t => new TransactionWithCardDto
				{
					TransactionId = t.Id,
					SourceCardNumber = t.SourceCard.CardNumber,
					DestinationCardNumber = t.DestinationCard.CardNumber,
					Amount = t.Amount,
					TransactionDate = t.TransactionDate,
					IsSuccessful = t.IsSucced ? "Succussfull":"Unsuccessfull"
				}).ToList();
		}

		public void Update(int id, Transaction updatedTransaction)
		{
			var transactionToUpdate = _dbContext.Transactions.FirstOrDefault(t => t.Id == id);
			if (transactionToUpdate != null)
			{
				transactionToUpdate.SourceCardId = updatedTransaction.SourceCardId;
				transactionToUpdate.DestinationCardId = updatedTransaction.DestinationCardId;
				transactionToUpdate.TransactionDate = updatedTransaction.TransactionDate;
				transactionToUpdate.Amount = updatedTransaction.Amount;
				transactionToUpdate.IsSucced = updatedTransaction.IsSucced;
				_dbContext.SaveChanges();
			}
		}
	}
}
