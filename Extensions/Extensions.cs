using System;
using System.Reflection;

namespace Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 获取世界标准时间(+8.00)时间
        /// </summary>
        /// <param name="date">原时间</param>
        /// <returns></returns>
       public static DateTime Local(this DateTime date)
        {
            return date.AddHours(8.00);
        }
    }
}
