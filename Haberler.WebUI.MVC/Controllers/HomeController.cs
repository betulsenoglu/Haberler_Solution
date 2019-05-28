using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Haberler.WebUI.MVC.Models;
using System.Net.Http;

namespace Haberler.WebUI.MVC.Controllers
{
    /// <summary>
    /// HomeController Error Action kontrolü içerir.
    /// </summary>
    public class HomeController : Controller
    {
        HttpClient _client;

        private const string webApiHaberUrl = "http://localhost:61255/api/haberler/";
        public IActionResult Index()
        {
            try
            {
            var news = GetHaberler();
            return View(news);
            }
            catch (Exception ex)
            {
                return View("Error_NotFound", ex.Message);
            }

        }
        public IActionResult SelectedNews(int Id)
        {
            try
            {
            var selectedNews = GetHaber(Id);
            if (selectedNews == null)
            {
                Response.StatusCode = 404;
                return View("Error", Id);
            }
            return View(selectedNews);
            }
            catch (Exception ex)
            {
                return View("Error_NotFound", ex.Message);
            }
        

        }
        public IActionResult AMPHaberler()
        {
            try
            {
                var news = GetHaberler();

                return View(news);
            }
            catch (Exception ex)
            {
                return View("Error_NotFound", ex.Message);
            }

        }
        public IActionResult AMPSelectedNews(int Id)
        {
            try
            {
                var selectedNews = GetHaber(Id);
                if (selectedNews == null)
                {
                    Response.StatusCode = 404;
                    return View("Error", Id);
                }
                return View(selectedNews);
            }
            catch (Exception ex)
            {
                return View("Error_NotFound", ex.Message);
            }


        }

        private Haber GetHaber(int id)
        {
            
            _client = new HttpClient();
            var response = _client.GetAsync(webApiHaberUrl + id).Result;
            var selectedNews = response.Content.ReadAsAsync<Haber>().Result;
            _client.Dispose();
            return selectedNews;
        }

        private IEnumerable<Haber> GetHaberler()
        {
            _client = new HttpClient();
            var response = _client.GetAsync(webApiHaberUrl).Result;
            var news = response.Content.ReadAsAsync<IEnumerable<Haber>>().Result;
            _client.Dispose();
            return news;
        }
    }
}
