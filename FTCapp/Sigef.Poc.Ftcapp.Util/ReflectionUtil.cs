using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Util
{
    public class ReflectionUtil<T>
    {

        public T GetPropertyValue<TPropType>(TPropType pObj, string propertie)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                {
                    if (propertie == prop.Name)
                    {
                        return (T)prop.GetValue(pObj);
                    }
                }
            return default(T);
        }

        public T GetPropertyValue(object pObj, string propertie)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                {
                    if (propertie == prop.Name)
                    {
                        return (T)prop.GetValue(pObj);
                    }
                }
            return default(T);
        }

        public PropertyInfo[] GetPropertiesInfo()
        {
            List<string> lt = new List<string>();
            return   typeof(T).GetProperties();
            
        }

        

        public void SetPropertyValue<U,V>(U pObj, string propertie, V value)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                {
                    if (propertie == prop.Name)
                    {
                        prop.SetValue(pObj,value);
                    }
                }
            
        }


        public static List<ObjectAttr> GetPropertyValues(Object objGetter)
        {
            List<ObjectAttr> ListObjectAttr = new List<ObjectAttr>();
            Type t = objGetter.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                {
                    ObjectAttr obj = new ObjectAttr { type = prop.PropertyType, FieldName = prop.Name, Value = prop.GetValue(objGetter) };
                    ListObjectAttr.Add(obj);
                }
            return ListObjectAttr;
        }


        public static void SetValueByNameIfExists(Object objSetter, string pName, object valueSetter)
        {
            Type t = objSetter.GetType();
            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                {
                    if (prop.Name.Equals(pName))
                    {
                        prop.SetValue(objSetter, valueSetter, null);
                    }
                }
        }


        public class ObjectAttr
        {
            public Type type { get; set; }
            public string FieldName { get; set; }
            public object Value { get; set; }

        }

       
    }
}
