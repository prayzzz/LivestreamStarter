using System.Collections.Generic;

namespace Common.Common
{
    public interface IItemsProvider<T>
    {
        int FetchCount();

        IList<T> FetchRange(int startIndex, int count);
    }
}