using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule.ScheduleCron
{
    public interface IScheduleCronService
    {
        Task SendNotification();
        Task CreateWallet(Guid id);
    }
}
