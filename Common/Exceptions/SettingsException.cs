using System;

namespace Common.Exceptions
{
    [Serializable]
    public class SettingsException : Exception
    {
        public SettingsException(string message)
            : base(message)
        {
        }
    }
}