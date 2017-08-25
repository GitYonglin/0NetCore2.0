using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntity
{
    /// <summary>
    /// 菜谱
    /// </summary>
    public class Cookbook
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
        /// 上架
        /// </summary>
        public bool Shelves { get; set; }
        /// <summary>
        /// 图文描述
        /// </summary>
        public List<Picturetext> PictureTexts { get; set; }
        /// <summary>
        /// 图文教程
        /// </summary>
        public List<Picturetext> PictureTextCoures { get; set; }
        /// <summary>
        /// 使用的食材
        /// </summary>
        public List<Foods> Foods { get; set; } = new List<BaseEntity.Foods>();
        /// <summary>
        /// 商品分类
        /// </summary>
        public List<string> GoodsCategorys { get; set; } = new List<string>();

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
}
