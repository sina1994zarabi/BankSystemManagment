namespace App.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public DateTime? LockTime { get; set; }

        // navigation property
        public List<Card> Cards { get; set; }

    }
}
