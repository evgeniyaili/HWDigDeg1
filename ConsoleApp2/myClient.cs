
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    internal class myClient 
    {
        private const string sortedFile = "D:\\ДигДесПроект\\Result\\Done3.txt";
        private const string myFile = "D:\\ДигДесПроект\\voyna-i-mir-tom-1.txt";
        static async Task Main(string[] args)
        {
            using (var myService = new ServiceReference1.Service1Client())
            {
                var result = myService.TextInput(myFile);

                StreamWriter streamwriter = new StreamWriter(sortedFile);
                foreach (var word in result)
                {
                    await streamwriter.WriteLineAsync(String.Format("{0} : {1}", word.Key, word.Value));
                }
                streamwriter.Close();
                Console.WriteLine("Результат расположен в D:\\ДигДесПроект\\Result\\Done3.txt");
            }
        }

    }
}
