using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TestDemo.Controllers;

namespace TestDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CreateTimer();           
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        public string Token()
        {
            string tokenvalue = RandomString(10);
            return tokenvalue;
        }

        public void CreateTimer()
        {
            var timer = new System.Timers.Timer(10000); // fire every 1 second
            timer.Elapsed += HandleTimerElapsed;
            timer.Enabled = true;
        }

        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Token();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
