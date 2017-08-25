using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Extensions
{
    public static class Func
    {
        public static T ObjToObj<T, T1>(T1 t1)
        {
            Type type = typeof(T);
            object t = Activator.CreateInstance(type, false);
            PropertyInfo[] PropertyList = type.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                item.SetValue(t, item.GetValue(t1, null));
            }
            return (T)t;
        }
    }
}
