using DoeAqui.Domain.Core.Commands;
using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T domainCommand) where T : Command;
        void SendEvent<T>(T domainEvent) where T : Event;
    }
}