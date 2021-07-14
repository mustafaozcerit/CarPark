using CarPark.Entities.Concrate;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CarPark.User.Models.Test;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        private readonly MongoClientSettings settings;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            settings  = MongoClientSettings.FromConnectionString("mongodb+srv://sa:Root64@carparkcluster.efzqx.mongodb.net/CarParkDB?retryWrites=true&w=majority");
        }

        public IActionResult Index()
        {
            var client = new MongoClient(settings);
            var database = client.GetDatabase("CarParkDB");

            var say_Hello_value = _localizer["Say_Hello"];


            var jsonString = System.IO.File.ReadAllText("cities.json");
            var cities = JsonConvert.DeserializeObject<List<cities>>(jsonString);

            var citiesCollection = database.GetCollection<City>("City");

            foreach (var item in cities)
            {
                var city = new City()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = item.name,
                    Plate = item.plate,
                    Latitude = item.latitude,
                    Longitude = item.longitude,
                    Counties = new List<County>()
                };
                foreach (var item2 in item.counties)
                {
                    city.Counties.Add(new County
                    {
                        Id=ObjectId.GenerateNewId(),
                        Name=item2,
                        Latitude="",
                        PostCode="",
                        Longitude="",
                    });
                }
                citiesCollection.InsertOne(city);
            }

            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //say_Hello_value = _localizer["Say_Hello"];

            var customer = new Customer
            {
                Id = 2,
                NameSurname = "Mustafa OZCERIT",
                Age = 28
            };
            _logger.LogError("Customer'de bir hata oluştu {@customer}",customer);

            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://sa:Root64@carparkcluster.efzqx.mongodb.net/CarParkDB?retryWrites=true&w=majority");
 

            //var collection = database.GetCollection<Test>("Test");
            //var test = new Test()
            //{
            //    _Id = ObjectId.GenerateNewId(),
            //    NameSurname = "Mustafa OZCERIT",
            //    Age = 24,
            //    AddressList = new List<Address>()
            //    {
            //        new Address
            //        {
            //            Title="Ev Adresim",
            //            Description="Gülcemal Sokak/Eskişehir"
            //        },
            //        new Address
            //        {

            //            Title="Baba Evi",
            //            Description="Akşehir/Konya"
            //        }
            //    }
            //};
            //collection.InsertOne(test);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
