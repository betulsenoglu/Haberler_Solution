using Haberler.WebUI.MVC.Models;
using HaberlerWebAPI.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestNews()
        {
            HaberlerController newsController = new HaberlerController();
            List<Haber> haber = newsController.Get();
            Assert.NotEmpty(haber);
        }
        [Fact]
        public void TestSelectedNews()
        {
            HaberlerController newsController = new HaberlerController();
            Haber haber = newsController.Get(123456);
            Assert.NotNull(haber);
        }
    }
}
