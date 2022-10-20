using myLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace myService
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]

    public class Service1 : IService1
    {
        public void TextInput(string myFile)
        {
            var book = File.ReadAllText(myFile);
            book = new string(book.Where(c => !char.IsPunctuation(c)).ToArray());
            book.ToLower();
            var sortedbook = book.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            textWorkClass textWorkClass = new textWorkClass();
            ConcurrentDictionary<string, int> myDictionary = new ConcurrentDictionary<string, int>();
            textWorkClass.parallelDictionary(myDictionary, sortedbook);

            User1 user1 = new User1();
            user1.context = OperationContext.Current;
            user1.context.GetCallbackChannel<IServiceCB>().OutputCB(myDictionary); //wut
        }
    }
}
