using BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Mongo.DAL.FoodCategoryDAL
{
    public class RFoodCategory : RBaseRepository<FoodCategory>, IFoodCategory
    {
        public RFoodCategory(IOptions<DbString> dbString) : base(dbString)
        {
        }
    }
}
