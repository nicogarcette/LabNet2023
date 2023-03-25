using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace Lab.EF.MVC.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public async Task<DogModel> Get() { 
        
            DogModel list = null;
            HttpClient httpClient = new HttpClient();
            string url = $"https://dog.ceo/api/breeds/image/random";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {

                var data = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<DogModel>(data);
            }

            return list;
        }
        public async Task<ActionResult> Index()
        {
            DogModel dogs = await Get();

            return View(dogs);
        }       
    }
}