using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ITransactionAppService
    {
        CardInfoDto GetDistinationInfo(string cardNumber);
        bool Transfer(int sourceCardId, int destinationCardId, decimal amount);
		List<TransactionWithCardDto> GetTransactionReport();
    }
}
