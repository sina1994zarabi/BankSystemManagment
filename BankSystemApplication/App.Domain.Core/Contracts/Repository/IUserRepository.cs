
using App.Domain.Core.Entities;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        User GetByUsername(string username);
        User GetByCardNumber(string cardNumber);
        void Update(int id, User newUser);
        void Delete(int id);
        void Save();

    }
}
