using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    public class ScheduleService : ISchedule
    {
        public Task<bool> SendNotification()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendSms(string customerCel, int minutes)
        {
            throw new NotImplementedException();
        }
    }
}
