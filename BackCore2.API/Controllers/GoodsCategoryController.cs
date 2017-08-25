using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.DAL.GoodsCategoryDAL;
using Microsoft.AspNetCore.Hosting;
using BaseEntity;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using Extensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackCore2.API.Controllers
{
    [Route("/[controller]")]
    public class GoodsCategoryController : Controller
    {
        private IGoodsCategory _goodsCategory;
        private string _webrootpath;

        public GoodsCategoryController([FromServices]IHostingEnvironment env, IGoodsCategory gc)
        {
            _webrootpath = env.WebRootPath;
            _goodsCategory = gc;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Get()
        {
            var v = Request.Host;
            IEnumerable<GoodsCategory> data = await _goodsCategory.GetAll();
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(GoodsCategory formData)
        {

            // 图片文件保存
            formData.SaveImgUrl = FileSave(formData.ImgFile);
            // 创建日期
            formData.CreateDate = DateTime.Now;
            // 更新日期
            formData.ModifyDate = DateTime.Now;
            //GoodsCategory seveData = Extensions.Func.ObjToObj<GoodsCategory, GoodsCategory>(formData);
            _goodsCategory.Insert(formData);
            IEnumerable<GoodsCategory> data = await _goodsCategory.GetAll();
            return Json(data);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(GoodsCategory formData)
        {
            // 图片文件保存
            formData.SaveImgUrl = FileSave(formData.ImgFile);
            
            // 过滤更新数据 ID
            var filter = Builders<GoodsCategory>.Filter.Eq(d => d.Id, formData.Id);
            // 获取更新数据集合
            var update = Mongo.Func.UpdateSet(formData);

            _goodsCategory.UpdateOne(filter, update);
            IEnumerable<GoodsCategory> data = await _goodsCategory.GetAll();
            return Json(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _goodsCategory.Delete(id);
            IEnumerable<GoodsCategory> data = await _goodsCategory.GetAll();
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
                var fileName = file.FileSaveOne($@"{_webrootpath}/upload/GoodsCategory");
                return $@"/upload/GoodsCategory/{fileName}";
            }
            return null;
        }
    }
}
