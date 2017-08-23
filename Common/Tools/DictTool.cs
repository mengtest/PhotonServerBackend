using System.Collections.Generic;

namespace Common.Tools
{
    public class DictTool
    {
        public static T2 GetValue<T1,T2>(Dictionary<T1, T2> dict, T1 key)
        {
            T2 value;
            bool isExit= dict.TryGetValue(key, out value);

            if (isExit)
            {
                return value;
            }
            else
            {
                return default(T2);
            }
        }
    }
}
