using BaseEntities;

namespace Services.Listener
{
    public interface IStreamUpdateListener
    {
        void Update(StreamModel model);

        void UpdateAll();
    }
}