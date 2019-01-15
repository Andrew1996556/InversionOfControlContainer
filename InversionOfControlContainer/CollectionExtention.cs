using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainer
{
    public static class CollectionExtention
    {
        public static bool SequenceEqualNotConsistently<T>(this IEnumerable<T> enumer1, IEnumerable<T> enumer2)
        {
            foreach (var item in enumer1)
            {
                if (!enumer2.Any(i => i.Equals(item)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
