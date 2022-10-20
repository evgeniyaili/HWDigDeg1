using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
  
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Dictionary<string,int> TextInput(string myFile);
    }
}

