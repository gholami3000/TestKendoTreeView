using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResponsibleChains;
using System.Diagnostics;
using Tamarack;
using Tamarack.Pipeline;
using TestKendoTreeView.Models;
using TestKendoTreeView.Models.validator;
using TestTree2;

namespace TestKendoTreeView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceProvider serviceProvider;
        private IMediator _mediator;


        public HomeController(ILogger<HomeController> logger, IMediator mediator, IServiceProvider serviceProvider
         )
        {
            _logger = logger;
            _mediator = mediator;

            this.serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            var model = new AddModel { RoutId = 1, Weight = 5 };

            //var pipeline = new Pipeline<AddModel, KscResult>(serviceProviderT)
            //.Add<CheckFreeSpaceInDestinationValidator1>()
           
            //.Finally(p => new KscResult() );

            //var newId = pipeline.Execute(post);


            //var chain =  serviceCollection.AddResponsibleChain<ITransactionValidatorChain>()
            //             .WithLink<CheckFreeSpaceInSourceValidator1>()
            //             .WithLink<CheckFreeSpaceInDestinationValidator1>()
            //             .Build();
            //var model = new AddModel { RoutId = 1, Weight = 5 };
            //var chain= transactionValidatorChain.Execute(model);
            //var chain = new ResponsibleChainBuilder<ITransactionValidatorChain>()
            //           .WithLink<CheckFreeSpaceInSourceValidator1>()
            //           .WithLink<CheckFreeSpaceInDestinationValidator1>()
            //           .Build();

            // var result = chain.Execute(model);
            //var model2 = new AddModel { RoutId = 2, Weight = 3 };
            //var list = new List<AddModel>();
            //list.Add(model);
            //list.Add(model2);

            //var resultHandler = Pipeline.Build<AddModel, KscResult>(x => x
            //         .Add<CheckFreeSpaceInSourceValidator>()
            //         .Add<CheckFreeSpaceInDestinationValidator>()//,type=> Activator.CreateInstance() //serviceProvider.GetService<MyServices>(typeof(MyServices))
            //        .Final(s => Task.FromResult(new KscResult
            //        {
            //            Success = true 
            //        })), type => Activator.CreateInstance(typeof(CheckFreeSpaceInSourceValidator))
            //    );



            //foreach (var item in list)
            //{
            //    var result = resultHandler.Invoke(item).Result;
            //    Console.WriteLine(result.Success);

            //}
            return View();
        }

        public async Task<IActionResult> SendNotificatio()
        {
            await _mediator.Publish(new NotificationModel { Message = "Ho" });
            return Json("ok");
        }

        public IActionResult A()
        {
            var list = new List<string> {
            "56000",
            "63000",
            "74000"
            };
            //Thread.Sleep(5000);
            return Json(list);
        }

        public IActionResult B()
        {
            var list = new List<string> {
            "100000",
            "34000",
            "23000"
            };
            //Thread.Sleep(5000);
            return Json(list);
        }

    }
}