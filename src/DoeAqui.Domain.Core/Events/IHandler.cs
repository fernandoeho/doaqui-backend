using DoeAqui.Domain.Core.Messages;

namespace DoeAqui.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}