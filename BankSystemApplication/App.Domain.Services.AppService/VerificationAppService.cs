using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Domain.Core.Contracts.AppService;

namespace App.Domain.Services.AppService
{
    public class VerificationAppService : IVerificationAppService
    {

        private const string filePath = @"C:\Users\dell\Desktop\code.txt";

        public int GenerateCode()
        {
            Random random = new Random();
            return random.Next(10000, 100000);
        }

        public DateTime SaveCode(string code)
        {
            DateTime timeGenerated = DateTime.Now;
            string messege = $"Verification Code: {code} - Date: {timeGenerated}\n";
            File.WriteAllText(filePath, messege);
            return timeGenerated;
        }
    }
}
