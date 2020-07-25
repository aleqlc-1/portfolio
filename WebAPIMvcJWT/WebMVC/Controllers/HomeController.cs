﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private static string WebAPIURL = "https://localhost:44330/";
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var tokenBased = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType:"application/json"));
                var responseMessage = await client.GetAsync(requestUri: "Account/ValidLogin?userName=sa&userPassword=sa");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultMessage = responseMessage.Content.ReadAsStringAsync().Result;
                    tokenBased = JsonConvert.DeserializeObject<string>(resultMessage);
                    Session["TokenNumber"] = tokenBased;
                    Session["UserName"] = "sa";
                }
            }
            return Content(tokenBased);
        }

        public async Task<ActionResult> GetEmployee()
        {
            string ReturnMessage = String.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer",
                    //parameter:Session["TokenNumber"].ToString() + ":" + "sa5");
                      parameter: Session["TokenNumber"].ToString() + ":" + Session["UserName"]);
                var responseMessage = await client.GetAsync(requestUri: "Account/GetEmployee");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultMessage = responseMessage.Content.ReadAsStringAsync().Result;
                    ReturnMessage = JsonConvert.DeserializeObject<string>(resultMessage);
                }
            }

            return Content(ReturnMessage);
        }
    }
}