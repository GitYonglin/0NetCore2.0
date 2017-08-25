using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntity
{
    /// <summary>
    /// 图片描述
    /// </summary>
    public class Picturetext
    {
        public string Desc { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        public IFormFile ImgFile { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>

        public string SaveImgUrl { get; set; }
        [BsonIgnore]
        public string ImgUrl
        {
            get => $@"http://localhost:5001" + SaveImgUrl;
        }
    }
    /// <summary>
    /// 使用食材
    /// </summary>
    public class Foods
    {
        /// <summary>
        /// 使用食材ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        public int Dosage { get; set; }
    }
}
