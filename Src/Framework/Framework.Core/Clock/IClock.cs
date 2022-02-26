using System;

namespace Framework.Core.Clock
{
  public interface IClock
    {
        DateTime Now();
        void SetClock(DateTime date);
        DateTime GetDateTime();
    }
}
