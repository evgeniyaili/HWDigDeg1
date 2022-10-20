using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace myService
{
    [ServiceContract (CallbackContract = typeof(IServiceCB))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void TextInput(string myFile);
    }

    [ServiceContract]
    public interface IServiceCB
    {
        [OperationContract (IsOneWay = true)]
        void OutputCB(ConcurrentDictionary<string,int> myDictionary);
    }
}
