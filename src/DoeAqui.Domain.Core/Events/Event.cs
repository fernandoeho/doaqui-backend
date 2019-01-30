using System;
using DoeAqui.Domain.Core.Messages;

namespace DoeAqui.Domain.Core.Events
{
    public class Event : Message
    {
        public Event()
        {
            DateTimeStamp = DateTime.UtcNow;
        }
    }
}