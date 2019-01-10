using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                List<int> a = "1,2,3,4,5,".ToList<int>(",");
                List<string> b = "1,2,3,4,5,".ToList<string>(",");

                Assert.AreNotSame(a, new List<int>() {1, 2, 3, 4, 5});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        
    }
    public static class StringEx
    {
        public static List<T> ToList<T>(this string str, string separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            List<T> result = new List<T>();
            var arrayList = str.Split(new []{ separator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arrayList)
            {
                var obj = (T)Convert.ChangeType(item, typeof(T));
                result.Add(obj);
            }

            return result;
        }
    }
}
