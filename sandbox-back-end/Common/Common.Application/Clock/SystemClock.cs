using System;

namespace Common.Application.Clock
{
    public class SystemClock : IClock
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
