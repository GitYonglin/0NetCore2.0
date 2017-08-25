using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaseEntity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace Mongo.DAL.FoodDAL
{
    public class RFood : RBaseRepository<Food>, IFood
    {
        private IMongoCollection<Food> _foodDb;
        public RFood(IOptions<DbString> dbString) : base(dbString)
        {
            _foodDb = DbCollection<Food>();
        }


        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public new async Task<object> GetPage(object p)
        {
            Page page = (Page)p;
            var projection = Builders<Food>.Projection
               .Expression(f => new
               {
                   Id = f.Id,
                   PictureText = f.PictureText,
                   Name = f.Name,
                   Dose = f.Dose,
                   Desc = f.Desc,
                   Shelves = f.Shelves,
                   UnitPrice = f.UnitPrice,
                   Inventory = f.Inventory,
                   MaxAmount = f.MaxAmount,
                   MinAmount = f.MinAmount,
                   MinNumber = f.MinNumber,
                   HedgeDate = f.HedgeDate,
                   PurchaseDate = f.PurchaseDate,
                   ModifyDateText = f.ModifyDateText
               });
            var builder = Builders<Food>.Filter;
            var filter = builder.Regex(f => f.Name, new BsonRegularExpression(new Regex(page.Name ?? "")));
            if (!(page.Food is null))
            {
                filter = filter & builder.All("FoodCategory", new[] { page.Food });
            }
            if (!(page.Good is null))
            {
                filter = filter & builder.All("GoodsCategory", new[] { page.Good });
            }
            var count = await _foodDb.Find(filter).CountAsync();
            //var data = _context.Find(filter).Skip(PageIndex).Limit(PageSize).Project(projection).ToList();
            var data = await _foodDb.Find(filter).Project(projection).Skip( page.Index* page.Size).Limit(page.Size).ToListAsync();
            return new { count = count, data = data };
        }
    }
}
