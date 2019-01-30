using System;
using DoeAqui.Domain.Core.Messages;

namespace DoeAqui.Domain.Core.Commands
{
    public class Command : Message
    {
        public Command()
        {
            DateTimeStamp = DateTime.UtcNow;
        }
    }
}