using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Entity.Enum
{
    public enum UserEnum
    {
        [Description("Customer")]
        Customer = 1,
        [Description("Manager")]
        Manager = 2
    }
}
