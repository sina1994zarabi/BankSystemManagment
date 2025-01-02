namespace App.Domain.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        
        public string CardNumber { get; set; }
        
        public string Passsword { get; set; }
        
        public decimal Balance { get; set; }
        public bool IsActive { get; set; } = true;

        // ForeignKey Property
        
        public int UserId { get; set; }
        public User User { get; set; }

        // navigation property
        public List<Transaction> SourceTransactions { get; set; }
        public List<Transaction> DestTransactions { get; set; }
    }
}
