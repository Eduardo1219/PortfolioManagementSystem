using Domain.Base.Repository;
using Domain.Product.Entity;
using Domain.User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
    }
}
