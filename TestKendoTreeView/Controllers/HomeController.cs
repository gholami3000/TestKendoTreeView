using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestKendoTreeView.Models;
using TestTree2;

namespace TestKendoTreeView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendNotificatio()
        {
            await _mediator.Publish(new NotificationModel { Message = "Ho" }) ;
            return Json("ok");
        }

        public IActionResult A()
        {
            Thread.Sleep(5000);
            return Json("A");
        }

        public IActionResult B()
        {
            Thread.Sleep(2000);
            return Json("B");
        }

    }
}