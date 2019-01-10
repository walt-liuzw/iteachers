using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public static class StringEx
    {
        public static List<T> ToList<T>(this string str,string separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            List<T> result = new List<T>();
            var arrayList = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arrayList)
            {
                var obj = (T)Convert.ChangeType(item, typeof(T));
                result.Add(obj);
            }

            return result;
        }
    }
}
