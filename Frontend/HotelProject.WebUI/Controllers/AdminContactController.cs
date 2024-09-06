using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5048/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5048/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            // E-posta Gönderimi (MailKit)
            MimeMessage mimeMessage = new MimeMessage();

            // Gönderen e-posta ve isim
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "hotelapi4@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            // Alıcı e-posta ve isim
            MailboxAddress mailboxAddressTo = new MailboxAddress(createSendMessageDto.ReceiverName, createSendMessageDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            // E-posta içeriği
            var bodyBuilder = new BodyBuilder
            {
                TextBody = createSendMessageDto.Content // Mesajın içeriği
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createSendMessageDto.Title; // Mesajın başlığı

            // SMTP ile e-posta gönderimi
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("hotelapi4@gmail.com", "dgmabrmsitmillxf");
                await client.SendAsync(mimeMessage);
                client.Disconnect(true);
            }

            // API'ye POST isteği gönderme (HttpClient)
            createSendMessageDto.SenderMail = "hotelapi4@gmail.com";
            createSendMessageDto.SenderName = "HotelierAdmin";
            createSendMessageDto.Date = DateTime.Now; // Mesajın gönderildiği tarih

            // HttpClient üzerinden API'ye veri gönderimi
            var clientHttp = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await clientHttp.PostAsync("http://localhost:5048/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox"); // Eğer işlem başarılıysa SendBox'a yönlendirilir
            }

            return View(createSendMessageDto); // Eğer hata olursa form tekrar gösterilir
        }


        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesseage = await client.GetAsync("http://localhost:5048/api/SendMessage");
            if (responseMesseage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesseage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

    }
}
