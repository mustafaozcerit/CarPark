using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        public UserController(IStringLocalizer<UserController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;  //Dil değiştirmemizi sağlıyor default değer bilgisayarın dilidir.

            var nameSurnameValue = _localizer["NameSurname"];
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {

            return View(request);
        }
    }
}
