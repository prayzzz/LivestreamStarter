using System;

namespace Common.Common
{
    [Serializable]
    public struct KeyValuePair<TK, TV>
    {
        public KeyValuePair(TK key, TV value)
            : this()
        {
            this.Key = key;
            this.Value = value;
        }

        public TK Key { get; set; }

        public TV Value { get; set; }
    }
}