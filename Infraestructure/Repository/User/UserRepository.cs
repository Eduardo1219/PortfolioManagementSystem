using Domain.Product.Entity;
using Domain.Product.Repository;
using Domain.User.Entity;
using Domain.User.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly PortfolioManagementContext _context;

        public UserRepository(PortfolioManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
