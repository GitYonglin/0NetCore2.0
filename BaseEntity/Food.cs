using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BaseEntity
{
    /// <summary>
    /// 食材
    /// </summary>
    public class Food
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 剂量
        /// </summary>
        public int Dose { get; set; }
        /// <summary>
        /// 上架
        /// </summary>
        public bool Shelves { get; set; }
        /// <summary>
        /// 最小购买数据
        /// </summary>
        public int MinNumber { get; set; }
        /// <summary>
        /// 最小购买剂量
        /// </summary>
        public int MinAmount { get; set; }
        /// <summary>
        /// 最高购买剂量
        /// </summary>
        public int MaxAmount { get; set; }
        /// <summary>
        /// 进货日期
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 保存日期
        /// </summary>
        public DateTime HedgeDate { get; set; }
        /// <summary>
        /// 厂家信息
        /// </summary>
        public VendorInformation VendorInformation { get; set; }
        /// <summary>
        /// 图文描述
        /// </summary>
        public List<Picturetext> PictureText { get; set; } = new List<Picturetext>();
        /// <summary>
        /// 食材分类
        /// </summary>
        public List<int> FoodCategory { get; set; } = new List<int>();
        /// <summary>
        /// 商品分类
        /// </summary>
        public List<string> GoodsCategory { get; set; } = new List<string>();
        /// <summary>
        /// 创建日期
        /// </summary>
        //private string createDate;
        //[JsonIgnore]
        public DateTime CreateDate { get; set; }
        [BsonIgnore]
        public string CreateDateText { get => CreateDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); }
        /// <summary>
        /// 修改日期
        /// </summary>ToLongDateString
        //[JsonIgnore]
        public DateTime ModifyDate { get; set; }
        [BsonIgnore]
        public string ModifyDateText { get => ModifyDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); }
    }

    /// <summary>
    /// 厂家信息
    /// </summary>
    public class VendorInformation
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInformation { get; set; }
        public string ProductionDate { get; set; }
        public string HarvestDate { get; set; }
    }


}
