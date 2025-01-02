namespace App.Domain.Core.Entities
{

    public class Transaction
    {
        
        public int Id { get; set; }
        
        public int SourceCardId { get; set; }
        public Card SourceCard { get; set; }
        
        public int DestinationCardId { get; set; }
        public Card DestinationCard { get; set; }
        
        
        public decimal Amount { get; set; }
        
        public DateTime TransactionDate { get; set; }
        
        public bool IsSucced { get; set; } = true;
    }
}
