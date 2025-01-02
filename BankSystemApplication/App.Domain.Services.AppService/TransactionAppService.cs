﻿using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infra.EfCore.Repositories;
using System.Transactions;
using App.Infra.Db;
using App.Domain.Services.Service;

namespace App.Domain.Services.AppService
{
    public class TransactionAppService : ITransactionAppService
    {
        ICardService _cardService;
        ITransactionService _transactionService;
        IUserRepository _userRepository;
        IVerificationAppService _verificationAppService;



        public TransactionAppService()
        {
            _cardService = new CardService();
            _transactionService = new TransactionService();
            _userRepository = new UserRepository();
            _verificationAppService = new VerificationAppService();
        }

        public CardInfoDto GetDistinationInfo(string cardNumber)
        {
            var user = _userRepository.GetByCardNumber(cardNumber);
            return new CardInfoDto { Cardnumber = cardNumber,Holdername = user.Name };
        }


        public bool Transfer(int sourceCardId,int destinationCardId,decimal amount)
        {
            var sourceCard = _cardService.GetCard(sourceCardId);
            var destinationCard = _cardService.GetCard(destinationCardId);
            if (sourceCard.Balance < amount) return false;

            decimal withdraw = 0;
            decimal deposit = amount;

            if (amount > 1000) withdraw = amount + (amount * 0.015m);
            else if (amount < 1000) withdraw = amount + (amount * 0.005m);

            sourceCard.Balance -= withdraw;
            destinationCard.Balance += deposit;

            _cardService.Save();

            Core.Entities.Transaction newTransaction = new Core.Entities.Transaction
            {
                SourceCardId = sourceCardId,
                DestinationCardId = destinationCardId,
                Amount = amount,
                TransactionDate = DateTime.Now,
            };

            _transactionService.Add(newTransaction);
            return true;
        }


        public List<TransactionWithCardDto> GetTransactionReport()
        {
            return _transactionService.GetAllTransaction();
        }
    }
}