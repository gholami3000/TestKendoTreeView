
using Microsoft.AspNetCore.Mvc;
using TestKendoTreeView.Models;
using TestTree2;

namespace Ksc.NewIronMaking.Web.Controllers
{
    public class UserRoleController : Controller
    {

        private readonly MyContext context;

        public UserRoleController(MyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult List()
        {
            var list = context.Roles.ToList();
            return new JsonResult(new { data = list, success = true, closeWindows = true });
        }

        [HttpGet]
        public IActionResult IndexTreeLocation(Guid roleId)
        {
            ViewBag.roleId = roleId;
            return View();
        }

        [HttpGet]
        public IActionResult GetTreeLocationList(Guid roleId)
        {
            var locationList = context.Locations.ToList();
            var tree = locationList.GenerateTree(x=>x.Id,x=>x.ParentId);
            return new JsonResult(new { data = tree, success = true, closeWindows = true });
        }


    }
}
