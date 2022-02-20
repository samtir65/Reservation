using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.TestsUtils.Models
{
    public class ReservationTestBuilder
    {
        public long Id { get; set; }
        public DateTime CreatOn { get; set; }
        public long CustomerId { get; set; }
        public long ServiceId { get; set; }
        public long PersonelId { get; set; }

        public class Build
        {
            public Build()
            {

            }
        }
    }

}
