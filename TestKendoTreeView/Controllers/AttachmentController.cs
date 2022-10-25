using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace TestKendoTreeView.Controllers
{
    public class AttachmentController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SaveFile()
        {
            using var client = new HttpClient();

            foreach (var file in Request.Form.Files)
            {
                if (file.Length <= 0)
                    continue;

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                    {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                    }, "File", fileName);

                    var response = await client.PostAsync("http://localhost:5065/WeatherForecast/AttachFile?name=ho", content);
                }
            }
            return Json("ok");
        }

    }
}
