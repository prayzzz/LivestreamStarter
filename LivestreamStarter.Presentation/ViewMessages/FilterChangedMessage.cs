using GalaSoft.MvvmLight.Messaging;

namespace LivestreamStarter.Presentation.ViewMessages
{
    public class FilterChangedMessage : MessageBase
    {
        public FilterChangedMessage(int gameId, bool isAllowed)
        {
            this.GameId = gameId;
            this.IsAllowed = isAllowed;
        }

        public int GameId { get; set; }

        public bool IsAllowed { get; set; }
    }
}