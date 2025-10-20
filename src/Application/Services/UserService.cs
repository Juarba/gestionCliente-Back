using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var u = await _repository.GetByIdAsync(id);
            if (u == null) return null;

            return new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password
            };
        }

        public async Task<UserDto?> GetByNameAsync(string name)
        {
            var u = await _repository.GetByNameAsync(name);
            if (u == null) return null;

            return new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password
            };
        }

        public async Task AddAsync(UserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Password = dto.Password
            };

            await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Password = dto.Password
            };

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}