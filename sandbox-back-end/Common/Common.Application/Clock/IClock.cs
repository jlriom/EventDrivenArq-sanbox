using System;

namespace Common.Application.Clock
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
