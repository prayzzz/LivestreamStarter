namespace Services.Interfaces
{
    public interface IStreamInteraction
    {
        void StreamStarted(string name);

        void StreamStarting();

        void StreamEnded();

        void StreamNotStarted();
    }
}