using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int> { 1, 6 };
            List<int> list2 = new List<int> { 1, 2, 3, 4, 5, 6 };

            // var result = from e1 in list1
            //             group e1 by (from e2 in list2)

            /* result = list1.GroupBy(e => list2.Contains(e), e => e,
                (key, g) =>
                {
                    Console.WriteLine(g);
                    return new { k = key, g };
                });*/

            var result2 = list1.GroupBy(e => list2.Contains(e)).ToList();

            var removeGroup = result2.ElementAt(0).Key ? (result2.Count > 1 ? result2.ElementAt(1).ToList() : new List<int>()) : result2.ElementAt(0).ToList();
            // var r = list1.AsParallel().Select(i => i * i);
            removeGroup.ForEach(i => Console.WriteLine(i));

            Console.ReadKey();
        }
    }
}
