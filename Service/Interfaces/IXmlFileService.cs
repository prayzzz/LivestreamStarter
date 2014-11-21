namespace Services.Interfaces
{
    public interface IXmlFileService
    {
        T Load<T>(string filePath) where T : class, new();

        void Save<T>(string filePath, T value);
    }
}