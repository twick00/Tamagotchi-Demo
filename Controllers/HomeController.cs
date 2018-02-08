using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using static System.Console;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/Home")]
        public IActionResult Home()
        {
            List<Tama> tamaList = Tama.GetAll();
            return View("Home");
        }
        [HttpGet("/Food/{id}")]
        public IActionResult Food(int id)
        {
            Tama tama = Tama.Find(id);
            return View("Food", tama);
        }
        [HttpPost("/Food/{id}")]
        public IActionResult PostFood(int id)
        {
            var tempTama = Request.Form["tamaId"];
            WriteLine(tempTama);
            Tama tama = Tama.Find(id);
            tama.SetHunger(tama.GetHunger()-20);
            if (tama.GetRest() < 20)
            {
                // TAMA DIES
            }
            else 
            {
                tama.SetRest(tama.GetRest() - 20);
            }
            return View("Food", tama);
        }
        [HttpGet("/Play/{id}")]
        public IActionResult Play(int id)
        {
            Tama tama = Tama.Find(id);
            return View("Play", tama);
        }
        [HttpPost("/Play/{id}")]
        public IActionResult PostPlay(int id)
        {
            Tama tama = Tama.Find(id);
            tama.SetFun(tama.GetFun()+20);
            if (tama.GetHunger() > 80)
            {
                // TAMA DIES
            }
            else 
            {
                tama.SetHunger(tama.GetHunger() - 20);
            }
            return View("Play", tama);
        }
        [HttpGet("/Sleep/{id}")]
        public IActionResult Sleep(int id)
        {
            Tama tama = Tama.Find(id);
            return View("Sleep", tama);
        }
        [HttpPost("/Sleep/{id}")]
        public IActionResult PostSleep(int id)
        {
            Tama tama = Tama.Find(id);
            tama.SetRest(tama.GetRest()+20);
            if (tama.GetFun() < 20)
            {
                // TAMA DIES
            }
            else 
            {
                tama.SetFun(tama.GetFun() - 20);
            }
            return View("Sleep", tama);
        }
        [HttpGet("/Create")]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost("/Status")]
        public IActionResult Status()
        {
            Tama tama = new Tama(Request.Form["tama-name"], 50);
            return View("Status", tama);
        }
        [HttpGet("/Status/{id}")]
        public IActionResult PostStatus(int id)
        {
            Tama tama = Tama.Find(id);
            return View("Status", tama);
        }
        [HttpGet("/Death/{id}")]
        public IActionResult Death (int id)
        {
            Tama tama = Tama.Find(id);
            return View("Death", tama);
        }
    }
}
