using JetLinkProject2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JetLinkProject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetResponseWithParam(string inputText)
        {
            string result = inputText;

            result = await AskYourQuestionAsync(inputText);

            var response = new { Output = result };

            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetResponse([FromBody] InputTextModel inputText) 
        {
            string result = inputText.UserText; ;

            result = await AskYourQuestionAsync(result);

            OutputTextModel response = new OutputTextModel() { 
                OutPut = result
            };

            return Json(response);
        }

        private async Task<string> AskYourQuestionAsync(string InputText)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    ChatGptReqModel model = new ChatGptReqModel();
                    ChatGptGetMessageModel  messageModel = new ChatGptGetMessageModel();
                    keys keys = new keys();
                    string apiUrl = "https://api.openai.com/v1/chat/completions";

                    string apiKey = keys.apiKey;

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    Message message = new Message();
                    message.role = "user";
                    message.content = "' "+ InputText + " '" + " cümlesindeki okuduğun tüm sayıları rakam olarak yazarak cümleyi bana söyle. Sadece cümle ile cevap ver";
                    List<Message> messages = new List<Message>();
                    messages.Add(message);

                    model.messages = messages;
                    string requestBody = JsonConvert.SerializeObject(model);

                    StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                    response.EnsureSuccessStatusCode();
                    string responseData = await response.Content.ReadAsStringAsync();

                    messageModel = JsonConvert.DeserializeObject<ChatGptGetMessageModel>(responseData);
                    if (messageModel != null)
                        return messageModel.choices[0].message.content;
                    else
                        return "Analiz başarısız! Lütfen yeni bir cümle ile deneyiniz.";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Hata oluştu: {ex.Message}";
               
            }
        }
    }
}