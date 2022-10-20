using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLib
{
    public class TextWorkClass
    {
        public void parallelDictionary(ConcurrentDictionary<string, int> myDictionary, string[] sortedbook)
        {
            Parallel.ForEach(sortedbook, word =>
            {
                myDictionary.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
            });
            
        }
    }
}
