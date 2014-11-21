using System.Collections.Generic;

using Logic.Dto;

namespace LivestreamStarter.Presentation.Common
{
    public class ViewerComparer : IComparer<StreamDto>
    {
        public int Compare(StreamDto x, StreamDto y)
        {
            return x.Viewers > y.Viewers ? -1 : 1;
        }
    }
}