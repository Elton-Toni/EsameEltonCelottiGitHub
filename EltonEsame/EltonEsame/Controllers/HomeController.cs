using EltonEsame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EltonEsame.Controllers
{
  public class HomeController : Controller
  {
    private DbConnectionString db = new DbConnectionString();
    public ActionResult Index()
    {
      var tickets = db.Tickets.Include(t => t.Registry).Include(t => t.Registry1).OrderByDescending(r => r.RequestDate).Take(10);
      return View(tickets.ToList());
    }

    public ActionResult NewUser()
    {
      return View();
    }

    public ActionResult Login()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}