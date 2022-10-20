using myLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WebApplication1
{
    
    public class Service1 : IService1
    {
        public Dictionary<string,int> TextInput(string myFile)
        {
            var book = File.ReadAllText(myFile);
            book = new string(book.Where(c => !char.IsPunctuation(c)).ToArray());
            book.ToLower();
            var sortedbook = book.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            TextWorkClass textWorkClass = new TextWorkClass();
            ConcurrentDictionary<string, int> myDictionary = new ConcurrentDictionary<string, int>();
            textWorkClass.parallelDictionary(myDictionary, sortedbook);
            return myDictionary.OrderByDescending(x => x.Value).ToDictionary(key=>key.Key, value=>value.Value);
        }
    }
}
