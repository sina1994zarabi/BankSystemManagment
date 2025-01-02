using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Infra.EfCore.Repositories;

namespace App.Domain.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetByCardNumber(string cardNumber)
        {
            return _userRepository.GetByCardNumber(cardNumber);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public void Save()
        {
            _userRepository.Save();
        }

        public void Update(int id, User newUser)
        {
            _userRepository.Update(id, newUser);
        }
    }
}
