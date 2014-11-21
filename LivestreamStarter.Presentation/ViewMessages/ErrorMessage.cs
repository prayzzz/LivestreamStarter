using GalaSoft.MvvmLight.Messaging;

namespace LivestreamStarter.Presentation.ViewMessages
{
    public class ErrorMessage : MessageBase
    {
        public ErrorMessage(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}