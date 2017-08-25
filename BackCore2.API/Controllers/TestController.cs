using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.DAL.FoodDAL;
using BaseEntity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackCore2.API.Controllers
{
    [Route("/[controller]/[action]")]
    public class TestController : Controller
    {
        private IFood _context;
        public TestController(IFood context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<Food> v = await _context.GetAll();
            return Json(v);
        }
        public async Task<IActionResult> One()
        {
            IEnumerable<Food> vv = await _context.GetAll();
            var vvv = vv.ToList();
            Food v = await _context.GetOne(vvv[0].Id);
            return Json(v);
        }
        public async Task<IActionResult> In()
        {
            _context.Insert(new Food() { Name = "陶子00000" });
            IEnumerable<Food> v = await _context.GetAll();
            return Json(v);
        }
    }
}
