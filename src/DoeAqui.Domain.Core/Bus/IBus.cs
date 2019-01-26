using DoeAqui.Domain.Core.Commands;
using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T command) where T : Command;
        void SendEvent<T>(T @event) where T : Event;
    }
}