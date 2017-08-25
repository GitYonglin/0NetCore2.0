using BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace Mongo.DAL.GoodsCategoryDAL
{
    public class RGoodsCategory : RBaseRepository<GoodsCategory>, IGoodsCategory
    {
        public RGoodsCategory(IOptions<DbString> dbString) : base(dbString)
        {
        }
    }
}
