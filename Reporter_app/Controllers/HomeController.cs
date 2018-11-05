using Reporter_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reporter_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Generate()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult saveClient(string nameClient, string lastNameClient, string accountNumberClient, string accountTypeClient)
        {
            var client = new Client();
            client.nameClient = nameClient;
            client.lastNameClient = lastNameClient;
            client.accountNumberClient = Convert.ToInt32(accountNumberClient);
            client.accountTypeClient = Convert.ToInt32(accountTypeClient);
            ClientData objClientData = new ClientData();
            objClientData.InsertClient(client)
                ;
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}