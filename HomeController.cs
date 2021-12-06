using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models.Home;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private string randomPass (int length)
        {
            Random passcode = new Random();
            string basePass = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string newPass = "";
            for (var i = 0; i <= length; i++){
                newPass += basePass[passcode.Next(basePass.Length)];
            }
            return newPass;
        }

        [HttpGet("")]
        public IActionResult Index(Passcode random)
        {
            if(HttpContext.Session.GetString("passcode") == null)
            HttpContext.Session.SetString("passcode", "Generate a Passcode!");
            if(HttpContext.Session.GetInt32("times") == null)
                HttpContext.Session.SetInt32("times", 0);

            random.randPass = HttpContext.Session.GetString("passcode");
            random.timesVisited = HttpContext.Session.GetInt32("times");

            return View(random);
        }
        [HttpGet("new")]
        public IActionResult NewPasscode(Passcode random2)
        {
            random2.timesVisited = HttpContext.Session.GetInt32("times");
            random2.timesVisited++;
            HttpContext.Session.SetInt32("times", (int)random2.timesVisited);
            HttpContext.Session.SetString("passcode", randomPass(14));
            return RedirectToAction("Index");
        }
    }
}