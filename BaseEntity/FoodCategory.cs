using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BaseEntity
{
    /// <summary>
    /// 食材分类
    /// </summary>
    public class FoodCategory
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        public int Id { get; set; }
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
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        //private string createDate;
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [BsonIgnore]
        public string CreateDateText { get => CreateDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); }
        /// <summary>
        /// 修改日期
        /// </summary>ToLongDateString
        [JsonIgnore]
        public DateTime ModifyDate { get; set; }
        [BsonIgnore]
        public string ModifyDateText { get => ModifyDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); }
    }
}
