using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntity
{
    public class Page
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 商品分类
        /// </summary>
        public string Good { get; set; }
        /// <summary>
        /// 食材分类
        /// </summary>
        public int? Food { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
