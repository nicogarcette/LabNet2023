using Lab.EF.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ProductsMLController : Controller
    {
        // GET: ProductsML
        public async Task<ActionResult> Index(string path)
        {
            Result products = await Get(path);

            return View(products.Results);
        }

        public async Task<Result> Get(string path) {

            Result list = null;
            HttpClient httpClient = new HttpClient();
            string url = $"https://api.mercadolibre.com/sites/MLA/search?q={path}&limit=3";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {

                var data = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<Result>(data);
            }

            return list;
        }
      
    }
}