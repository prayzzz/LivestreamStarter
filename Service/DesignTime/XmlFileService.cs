using System;

using Services.Interfaces;

namespace Services.DesignTime
{
    public class XmlFileService : IXmlFileService
    {
        public T Load<T>(string filePath) where T : class, new()
        {
            return Activator.CreateInstance<T>();
        }

        public void Save<T>(string filePath, T value)
        {
        }
    }
}