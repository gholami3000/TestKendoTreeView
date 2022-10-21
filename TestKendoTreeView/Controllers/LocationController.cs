
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestKendoTreeView.Models;
using TestKendoTreeView.Services;
using TestTree2;

namespace Ksc.NewIronMaking.Web.Controllers
{
    public class LocationController : Controller
    {

        private readonly MyContext context;
        private readonly CacheService cache;

        public LocationController(MyContext context, CacheService cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var list=new List<Location>();
             list = cache.Get<List<Location>>("locationList");
            if (list is not null)
            {
                Console.WriteLine("Exist in cache , Data Read From cache");
            }
            if (list is null )
            {
                list = context.Locations.ToList();

                cache.Set<List<Location>>("locationList",list,TimeSpan.FromSeconds(1));
                //bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                //if (!isDevelopment)
                //{
                //    // _SMSSender.SendMessageAsync(mobileNumber, code);
                //}
                //value = _cache.Get<VerificationCode>(mobileNumber);
            }           

            return new JsonResult(new { data = list, success = true, closeWindows = true });
        }

        public async Task<IActionResult> Create()
        {
            var model = new Location
            {

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location model)
        {
            model.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                context.Locations.Add(model);
                await context.SaveChangesAsync();
                return new JsonResult(new { data = model, success = true, closeWindows = true });
            }
            return new JsonResult(new { data = model, success = false, closeWindows = false });
        }

        public async Task<IActionResult> CreateChild(Guid id)
        {
            var model = new Location
            {
                ParentId = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateChild(Location model)
        {
            model.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                context.Locations.Add(model);
                await context.SaveChangesAsync();
                return new JsonResult(new { data = model, success = true, closeWindows = true });
            }
            return new JsonResult(new { data = model, success = false, closeWindows = false });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await context.Locations.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Location model)
        {

            if (ModelState.IsValid)
            {
                context.Update(model);
                await context.SaveChangesAsync();
            }


            return new JsonResult(new { data = model, success = true, closeWindows = true });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await context.Locations.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var entity = await context.Locations.FindAsync(id);
            context.Locations.Remove(entity);
            await context.SaveChangesAsync();
            return new JsonResult(new { success = true, closeWindows = true });
        }


        public async Task<IActionResult> ShowChart()
        {
            //var entity = await context.Locations.FindAsync(id);
            //context.Locations.Remove(entity);
            //await context.SaveChangesAsync();
            //return new JsonResult(new { success = true, closeWindows = true });
            return View();
        }

        public async Task<IActionResult> GetChartData()
        {
            var list = await context.Locations.ToListAsync();
            //context.Locations.Remove(entity);
            //await context.SaveChangesAsync();
            return new JsonResult(new { data= list, success = true, closeWindows = true });
        }

    }
}
