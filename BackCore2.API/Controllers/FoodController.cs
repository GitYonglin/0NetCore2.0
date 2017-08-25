using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.DAL.FoodDAL;
using BaseEntity;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Driver;
using Extensions;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System.Text.RegularExpressions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackCore2.API.Controllers
{
    [Route("/[controller]")]
    public class FoodController : Controller
    {
        private IFood _Food;
        private string _webrootpath;

        public FoodController([FromServices]IHostingEnvironment env, IFood fc)
        {
            _webrootpath = env.WebRootPath;
            _Food = fc;
        }
        // GET: /<controller>/
        [Route("/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Page(Page p)
        {
            var data = await _Food.GetPage(p);
            return Json(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var v = Request.Host;
            Food data = await _Food.GetOne<string>(id);
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Food formData)
        {

            //图片文件保存
            if (!(formData.PictureText is null))
            {
                foreach (var item in formData.PictureText)
                {
                    item.SaveImgUrl = FileSave(item.ImgFile);
                }
            }
            // 创建日期
            formData.CreateDate = DateTime.Now;
            // 更新日期
            formData.ModifyDate = DateTime.Now;
            //Food seveData = Extensions.Func.ObjToObj<Food, Food>(formData);
            _Food.Insert(formData);
            IEnumerable<Food> data = await _Food.GetAll();
            return Json(formData);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Food formData)
        {
            formData.ModifyDate = DateTime.Now;
            // 图片文件保存
            if (!(formData.PictureText is null))
            {
                foreach (var item in formData.PictureText)
                {
                    if (!(item.ImgFile is null))
                    {
                        item.SaveImgUrl = FileSave(item.ImgFile);
                    }
                }
            }

            //// 过滤更新数据 ID
            var filter = Builders<Food>.Filter.Eq(d => d.Id, formData.Id);
            _Food.Replace(filter, formData);
            IEnumerable<Food> data = await _Food.GetAll();
            return Json(data);
        }

        [Route("/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Update(Food formData)
        {
            //// 过滤更新数据 ID
            var filter = Builders<Food>.Filter.Eq(d => d.Id, formData.Id);
            var update = Builders<Food>.Update.Set(f => f.UnitPrice, formData.UnitPrice)
                .Set(f => f.Inventory, formData.Inventory)
                .Set(f => f.Shelves, formData.Shelves)
                .Set(f => f.HedgeDate, formData.HedgeDate)
                .Set(f => f.PurchaseDate, formData.PurchaseDate)
                .Set(f => f.ModifyDate, DateTime.Now)
                ;
            _Food.UpdateOne(filter, update);
            IEnumerable<Food> data = await _Food.GetAll();
            return Json(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _Food.Delete(id);
            IEnumerable<Food> data = await _Food.GetAll();
            return Json(data);
        }
        /// <summary>
        /// 保存图片获取保存路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string FileSave(IFormFile file)
        {
            if (!(file is null))
            {
                // 完成域名
                var httpPath = $@"http://{Request.Host}";
                // 保存文件获取文件名称
                var fileName = file.FileSaveOne($@"{_webrootpath}/upload/Food");
                return $@"/upload/Food/{fileName}";
            }
            return null;
        }
    }
}
