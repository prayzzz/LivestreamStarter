using System;
using System.IO;
using System.Xml.Serialization;

using Common.Common;
using Common.Enum;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace Services.Services
{
    public class XmlFileService : IXmlFileService
    {
        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        public T Load<T>(string filePath) where T : class, new()
        {
            Logger.Log(LogTypeEnum.Start, "loading file: {0}", filePath);

            if (!File.Exists(filePath))
            {
                Logger.Log(LogTypeEnum.Work, "file doesn't exist: {0}", filePath);
                Logger.Log(LogTypeEnum.Work, "creating file: {0}", filePath);
                this.Save(filePath, new T());
            }

            T value = null;

            try
            {
                using (var sw = new StreamReader(filePath))
                {
                    var xmls = new XmlSerializer(typeof(T));
                    value = xmls.Deserialize(sw) as T;
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }

            Logger.Log(LogTypeEnum.Stop, "loading file: {0}", filePath);

            return value;
        }

        public void Save<T>(string filePath, T value)
        {
            Logger.Log(LogTypeEnum.Work, "saving file: {0}", filePath);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    var xmls = new XmlSerializer(typeof(T));
                    xmls.Serialize(sw, value);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }

            Logger.Log(LogTypeEnum.Stop, "saving file: {0}", filePath);
        }
    }
}