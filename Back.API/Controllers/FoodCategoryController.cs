using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.DAL.FoodCategoryDAL;
using BaseEntity;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Driver;
using Extensions;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackCore2.API.Controllers
{
    [Route("/[controller]")]
    public class FoodCategoryController : Controller
    {
        private IFoodCategory _foodCategory;
        private string _webrootpath;

        public FoodCategoryController([FromServices]IHostingEnvironment env, IFoodCategory fc)
        {
            _webrootpath = env.WebRootPath;
            _foodCategory = fc;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Get()
        {
            var v = Request.Host;
            IEnumerable<FoodCategory> data = await _foodCategory.GetAll();
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(FoodCategory formData)
        {

            // 图片文件保存
            formData.ImgUrl = FileSave(formData.ImgFile);
            // 创建日期
            formData.CreateDate = DateTime.Now;
            // 更新日期
            formData.ModifyDate = DateTime.Now;
            //FoodCategory seveData = Extensions.Func.ObjToObj<FoodCategory, FoodCategory>(formData);
            _foodCategory.Insert(formData);
            IEnumerable<FoodCategory> data = await _foodCategory.GetAll();
            return Json(data);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(FoodCategory formData)
        {
            // 图片文件保存
            formData.ImgUrl = FileSave(formData.ImgFile);
            
            // 过滤更新数据 ID
            var filter = Builders<FoodCategory>.Filter.Eq(d => d.Id, formData.Id);
            // 获取更新数据集合
            var update = Mongo.Func.UpdateSet(formData);

            _foodCategory.UpdateOne(filter, update);
            IEnumerable<FoodCategory> data = await _foodCategory.GetAll();
            return Json(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _foodCategory.Delete(id);
            IEnumerable<FoodCategory> data = await _foodCategory.GetAll();
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
                var fileName = file.FileSaveOne($@"{_webrootpath}/upload/FoodCategory");
                return $@"{httpPath}/upload/FoodCategory/{fileName}";
            }
            return null;
        }
    }
}
