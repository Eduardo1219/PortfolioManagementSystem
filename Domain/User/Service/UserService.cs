using Domain.Product.Entity;
using Domain.User.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task AddUserAsync(UserEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateUserAsync(UserEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<int> GetCountAsync(string? search, string? email, bool? active, UserEnum? permission)
        {
            return await _repository.GetCountAsync(p =>
            !string.IsNullOrEmpty(search) ? (p.Name.Contains(search) || p.LastName.Contains(search)) : true &&
            (!string.IsNullOrEmpty(email) ? p.Email.Contains(email) : true) &&
            (permission.HasValue ? p.Permission == permission.Value : true) &&
            (active.HasValue ? p.Active == active.Value : true));
        }


        public async Task<List<UserEntity>> GetPagedAsync(int take, int skip, string? search, string? email, bool? active, UserEnum? permission)
        {
            var products = await _repository.GetPagedAscAsync(p =>
            !string.IsNullOrEmpty(search) ? (p.Name.Contains(search) || p.LastName.Contains(search)) : true &&
            (!string.IsNullOrEmpty(email) ? p.Email.Contains(email) : true) &&
            (permission.HasValue ? p.Permission == permission.Value : true) &&
            (active.HasValue ? p.Active == active.Value : true),
            take,
            skip,
            p => p.Name);

            return products.ToList();
        }
    }
}
