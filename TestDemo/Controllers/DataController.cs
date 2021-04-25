using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using System.Web.Http;
using static TestDemo.Models.BusinessLogic;

namespace TestDemo.Controllers
{
    [RoutePrefix("api")]
    public class DataController : ApiController
    {
        [Route("signin")]
        [HttpPost]
        public async Task<IHttpActionResult> GetMethod(HttpRequestMessage message)
        {
            try
            {
                string token = string.Empty;
                var req = await message.Content.ReadAsStringAsync();
                var headers = message.Headers;
                if (headers.Contains("Token"))
                {
                    token = headers.GetValues("Token").First();
                }
                string temptoken = "jhgjbjh";
                if (token == temptoken)
                {
                    return Json(new
                    {
                        Message = "Invalid Token"
                    });
                }
                var user = ConfigurationManager.AppSettings["Username"];
                var pass = ConfigurationManager.AppSettings["Password"];
                signin login = JsonConvert.DeserializeObject<signin>(req);
                if (login.Username == user || login.Password == pass)
                {
                    return Json(new
                    {
                        Message = "Credentials is successfully authenticated"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Message = "Please check you login Credentials"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = ex
                });
            }
            
        }
        
    }
}
