using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mongo
{
    public static class Func
    {
        /// <summary>
        /// 更新数据获取
        /// </summary>
        /// <typeparam name="T">更新数据类型</typeparam>
        /// <param name="t">跟新数据实体</param>
        /// <returns></returns>
        public static UpdateDefinition<T> UpdateSet<T>(T t)
        {
            var update = Builders<T>.Update.Set("ModifyDate", DateTime.Now.ToLocalTime());

            // 不需要属性名称
            var names = new string[] { "Id", "ModifyDate", "CreateDate" };
            // 空值不更新  时间没有设置不更新
            var values = new string[] { "", new DateTime().ToString() };
            Type type = typeof(T);
            PropertyInfo[] PropertyList = type.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                // 获取属性值
                var value = Convert.ToString(item.GetValue(t, null));
                //var value = Convert.ChangeType(item.GetValue(t), item.PropertyType);
                //value.GetType();
                // 不加数据库的指定attribute
                var attribute = item.GetCustomAttribute(typeof(BsonIgnoreAttribute));
                if (attribute is null
                    && !(values.Contains(value)) 
                    && !names.Contains(item.Name)
                   )
                {
                    // 这里有点不理解为什么要这样 还要等于一次??
                    update = update.Set(item.Name, value);
                }
            }
            return update;
        }
    }
}
