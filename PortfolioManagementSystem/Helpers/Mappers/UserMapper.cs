using Domain.User.Entity;
using PortfolioManagementSystem.Controllers.Users.Dto;

namespace PortfolioManagementSystem.Helpers.Mappers
{
    public static class UserMapper
    {
        public static UserEntity UserDtoMapper(this UserDto dto)
        {
            var entity = new UserEntity
            {
                Active = dto.Active,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                LastName = dto.LastName,
                Name = dto.Name,
                Permission = dto.Permission
            };
         
            return entity;
        }

        public static UserEntity UserDtoUpdateMapper(UserEntity userEntity, UserDto dto)
        {
            var entity = new UserEntity
            {
                Active = dto.Active,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                LastName = dto.LastName,
                Name = dto.Name,
                Permission = dto.Permission,
                CreatedAt = userEntity.CreatedAt,
                Id = userEntity.Id,
                LastChangeDate = DateTime.UtcNow.AddHours(-3)
            };

            return entity;
        }


    }
}
