using CodeChallenge_JS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeChallenge_JS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DataContext _context = new DataContext();
        public ActionResult Index()
        {
            var messages = _context.Messages.OrderByDescending(x => x.Date).Take(50).OrderBy(x => x.Date).ToList();
            return View(messages);
        }

        [HttpPost]
        public async Task<string> BotCall(string key)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://stooq.com/q/l/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync(String.Format("https://stooq.com/q/l/?s={0}&f=sd2t2ohlcv&h&e=csv", key));

                    string responseCSV = "";
                    if (response.IsSuccessStatusCode)
                    {
                        responseCSV = await response.Content.ReadAsStringAsync();
                        var line = responseCSV.Split('\n')[1];
                        var quote = line.Split(',')[6];
                        var symbol = line.Split(',')[0];
                        return  string.Format("{0} quote is {1:C} per share", symbol, quote);
                    }

                    return key + " NOT FOUND";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Code Challenge";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Carlos Javier Flores Kanter";

            return View();
        }
    }
}