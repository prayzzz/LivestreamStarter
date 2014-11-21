using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class ProcessException : Exception
    {
        public ProcessException(string message) : base(message)
        {
        }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Message", this.Message);
        }
    }
}