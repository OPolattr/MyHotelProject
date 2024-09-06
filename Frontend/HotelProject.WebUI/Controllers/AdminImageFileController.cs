using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(content, "file", file.FileName);

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.PostAsync("http://localhost:5048/api/FileImage", multipartFormDataContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }
    }
}
