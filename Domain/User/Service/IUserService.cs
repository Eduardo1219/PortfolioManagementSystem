using Domain.User.Entity.Enum;
using Domain.User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Service
{
    public interface IUserService
    {
        Task AddUserAsync(UserEntity entity);
        
        Task UpdateUserAsync(UserEntity entity);
        
        Task<UserEntity> GetUserByIdAsync(Guid Id);
        
        Task<int> GetCountAsync(string? search, string? email, bool? active, UserEnum? permission);
        
        Task<List<UserEntity>> GetPagedAsync(int take, int skip, string? search, string? email, bool? active, UserEnum? permission);
    }
}
