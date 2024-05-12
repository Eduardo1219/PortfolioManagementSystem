using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule.Entity
{
    public class NotificationTemplate
    {
        public string DescriptionProduct {  get; set; }
        public DateTime DueTime { get; set; }
    }
}
