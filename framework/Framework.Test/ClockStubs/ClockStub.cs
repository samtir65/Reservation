using Framework.Core.Clock;
using System;

namespace Framework.Test.ClockStubs
{
    public class ClockStub : IClock
    {
        private  DateTime? _date;
        public ClockStub(DateTime date)
        {
            _date = date;
        }
        public DateTime GetDateTime()
        {
            if (_date.HasValue)
                return _date.Value;
            return DateTime.Now;
        }
        
        public DateTime Now()
        {
            if (_date.HasValue)
                return _date.Value;
            return DateTime.Now;
        }

        public void SetClock(DateTime date)
        {
            _date = date;
        }
    }
}
