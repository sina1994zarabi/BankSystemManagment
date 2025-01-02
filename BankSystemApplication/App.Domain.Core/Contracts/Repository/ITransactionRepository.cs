
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface ITransactionRepository
    {
        void Add(Transaction newTransaction);

        List<TransactionWithCardDto> GetAllTransaction();

        void Update(int id, Transaction updatedTransaction);

        void Delete(int id);
    }
}
