using System.Collections.Generic;

namespace ZeroProject.Extensions.ListExtensions
{
    public static class ListExtension
    {
        public static T RandomItem<T>(this List<T> list)
        {
            if (list.Count > 1)
            {
                var index = UnityEngine.Random.Range(0, list.Count);
                return list[index];
            }

            return list[0];
        }

        public static T Last<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }
        
        public static T First<T>(this List<T> list)
        {
            return list[0];
        }
    }
}