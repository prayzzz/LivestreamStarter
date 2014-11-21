using System;

namespace Common.Args
{
    public class StreamEndedArgs : EventArgs
    {
        public TimeSpan RunTime { get; set; }
    }
}