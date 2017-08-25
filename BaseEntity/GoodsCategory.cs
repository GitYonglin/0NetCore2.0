using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntity
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class GoodsCategory
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
        /// 图片文件
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public IFormFile ImgFile { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonIgnore]
        public string SaveImgUrl { get; set; }
        [BsonIgnore]
        public string ImgUrl
        {
            get => $@"http://localhost:5001" + SaveImgUrl;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public string UpId { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        //private string createDate;
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [BsonIgnore]
        public string CreateDateText { get { return this.CreateDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); } }
        /// <summary>
        /// 修改日期
        /// </summary>ToLongDateString
        [JsonIgnore]
        public DateTime ModifyDate { get; set; }
        [BsonIgnore]
        public string ModifyDateText { get { return this.ModifyDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); } }
    }
}
