using System;

namespace DoeAqui.Domain.Core.Messages
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public Guid AggregateId { get; protected set; }
        public string MessageType { get; protected set; }
        public DateTime DateTimeStamp { get; protected set; }
    }
}