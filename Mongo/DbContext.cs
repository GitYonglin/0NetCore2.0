using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo
{
    public class DbContext
    {
        private readonly IMongoDatabase database;

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="settings"></param>
        public DbContext(IOptions<DbString> dbString)
        {

            var client = new MongoClient(dbString.Value.ConnectionString);
            database = client.GetDatabase(dbString.Value.DatabaseName);
        }
        /// <summary>
        /// 连接集合(Collection)
        /// </summary>
        /// <returns>返回连接集合</returns>
        public virtual IMongoCollection<T> DbCollection<T>() where T : class
        {
            return database.GetCollection<T>(typeof(T).Name);
        }
    }
    public class DbString
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 连接数据库名称
        /// </summary>
        public string DatabaseName { get; set; }
    }
}
