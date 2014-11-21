using GalaSoft.MvvmLight.Messaging;

namespace LivestreamStarter.Presentation.ViewMessages
{
    public class StreamActionMessage : MessageBase
    {
        public StreamActionMessage(StreamActionEnum action, int? id)
        {
            this.Action = action;
            this.Id = id;
        }

        public StreamActionEnum Action { get; private set; }

        public int? Id { get; private set; }
    }
}