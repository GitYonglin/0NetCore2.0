using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;
using BaseEntity;

namespace Mongo.DAL
{
    public class RBaseRepository<T> : DbContext, IBaseRepository<T> where T : class
    {
        private IMongoCollection<T> _context;
        public RBaseRepository(IOptions<DbString> dbString) : base(dbString)
        {
            _context = DbCollection<T>();
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Find(_ => true).ToListAsync();
        }
        /// <summary>
        /// id获取一条数据
        /// </summary>
        /// <typeparam name="T1">id类型</typeparam>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<T> GetOne<T1>(T1 id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _context.Find(filter).FirstOrDefaultAsync();
        }
        

        public void Insert(T t)
        {
            var vv = _context.InsertOneAsync(t);
        }

        public async void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            await _context.UpdateOneAsync(filter, update);
        }

        public async void Delete<T1>(T1 Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);
            await _context.DeleteOneAsync(filter);
        }

        public async void Replace(FilterDefinition<T> filter, T date)
        {
            var result = await _context.ReplaceOneAsync(filter, date);
        }

        public Task<object> GetPage(object p)
        {
            throw new NotImplementedException();
        }
    }
}
