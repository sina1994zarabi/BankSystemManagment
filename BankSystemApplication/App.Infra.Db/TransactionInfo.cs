using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Db
{
	public static class TransactionInfo
	{
        public  static int  SourceCardId { get; set; }
        public  static int  DestinationCardId { get; set; }
        public  static int  VerificationCode { get; set; }
        public  static DateTime VerificationCodeGeneratedAt { get; set; }
        public  static decimal Amount { get; set; }
    }
}
