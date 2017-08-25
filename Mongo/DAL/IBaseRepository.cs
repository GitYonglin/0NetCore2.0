using BaseEntity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DAL
{

    /// <summary>
    /// 所有数据访问顶层接口
    /// </summary>
    /// <typeparam name="T">实现类</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Id获取一条数据
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<T> GetOne<T1>(T1 id);
        /// <summary>
        /// 分页获取指定数据
        /// </summary>
        /// <param name="PageIndex">第几页</param>
        /// <param name="PageSize">每页几条</param>
        /// <returns></returns>
        Task<Object> GetPage(object p);
        //Task<IEnumerable<T>> Like(string[] arr);
        //Task<IEnumerable<T>> Any(string s);
        //Task<IEnumerable<Object>> Project();
        //Task<IEnumerable<Object>> Lookup();
        /// <summary>
        /// 插入一条新纪录
        /// </summary>
        /// <param name="t"></param>
        void Insert(T t);
        void Replace(FilterDefinition<T> filter, T date);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="update">更新数据</param>
        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="filter"></param>
        void Delete<T1>(T1 Id);
    }
}
