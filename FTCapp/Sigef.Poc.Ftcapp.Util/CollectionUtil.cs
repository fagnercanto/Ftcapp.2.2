using System.Collections.Generic;
using System.Linq;

namespace Sigef.Poc.FTCapp.Util
{
    public static class CollectionUtil
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            /* If this is a list, use the Count property for efficiency. 
             * The Count property is O(1) while IEnumerable.Count() is O(N). */
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }
            return !enumerable.Any();
        }

        public static int IsNullOrEmptyReturnCount<T>(this IEnumerable<T> enumerable)
        {
            int result = 0;

            if (!IsNullOrEmpty(enumerable))
            {
                result = enumerable.Count();
            }

            return result;



        }






    }
}
