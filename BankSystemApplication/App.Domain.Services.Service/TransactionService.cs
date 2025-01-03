using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infra.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Add(Transaction newTransaction)
        {
            _transactionRepository.Add(newTransaction);
        }

        public void Delete(int id)
        {
            _transactionRepository.Delete(id);
        }

        public List<TransactionWithCardDto> GetAllTransaction()
        {
            return _transactionRepository.GetAllTransaction();
        }

        public void Update(int id, Transaction updatedTransaction)
        {
            _transactionRepository.Update(id, updatedTransaction);
        }
    }
}
