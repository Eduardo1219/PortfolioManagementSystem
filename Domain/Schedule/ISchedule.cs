using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    public interface ISchedule
    {
        public Task<bool> SendNotification();
        Task<bool> SendSms(string customerCel, int minutes);
    }
}
