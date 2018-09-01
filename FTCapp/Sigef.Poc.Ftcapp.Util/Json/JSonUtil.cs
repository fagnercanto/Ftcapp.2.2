
using Newtonsoft.Json;
using System;

namespace Sigef.Poc.Ftcapp.Util.Jason
{
    public class JsonUtil{
    

       #region Json Convert

       public object StringToObjectConverter(string content, object obj){
            Type t = obj.GetType();
            obj =  JsonConvert.DeserializeObject<Type>(content);
            return obj;
        }

        public  string ObjectToStringConverter(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        

        #endregion


    }
    
        
}
