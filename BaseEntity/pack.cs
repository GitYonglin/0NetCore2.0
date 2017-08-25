using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntity
{
    /// <summary>
    /// 套餐
    /// </summary>
    public class Pack
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
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
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 图文描述
        /// </summary>
        public Picturetext[] PictureText { get; set; }
        /// <summary>
        /// 使用食材
        /// </summary>
        public Foods[][] PackFoods { get; set; }
        /// <summary>
        /// 使用菜谱
        /// </summary>
        public Cookbooks[] Cookbooks { get; set; }
        /// <summary>
        /// 商品分类
        /// </summary>
        public int[] GoodsCategorys { get; set; }
    }

    /// <summary>
    /// 使用菜谱
    /// </summary>
    public class Cookbooks
    {
        public string Id { get; set; }
        public int Dosage { get; set; }
    }

}
