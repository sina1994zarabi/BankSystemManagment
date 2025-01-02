using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos
{
    public class TransactionWithCardDto
    {
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string IsSuccessful { get; set; }
    }
}
