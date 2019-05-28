using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haberler.WebUI.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HaberlerWebAPI.Controllers
{
    [Route("api/haberler")]
    [ApiController]
    public class HaberlerController : ControllerBase
    {
        //IMemoryCache _memoryCache;
        //public NewsController(IMemoryCache memoryCache)
        //{
        //    _memoryCache = memoryCache;
        //}


        /// <summary>
        /// Error Handling MVC katmanında View yönlendirmesi ile saglanmistir. 
        /// </summary>


        /// <summary>
        /// DataSource olarak json dosyası okuduğumuz metot AllNews metodudur.
        /// </summary>
        private List<Haber> AllNews()
        {
            string text = System.IO.File.ReadAllText(@"AppData\news.json");
            return JsonConvert.DeserializeObject<List<Haber>>(text);
        }

        // GET /haberler 
        /// <summary>
        /// Tum haberleri listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Haber> Get()
        {
            return AllNews();

        }

        /// <summary>
        /// Idye gore haber getirir.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET /haberler-123456
        [HttpGet("{id}")]
        public Haber Get(int Id)
        {
            Haber selectedNews = AllNews().Where(x => x.Id == Id).FirstOrDefault();
            return selectedNews;

        }

    }
}