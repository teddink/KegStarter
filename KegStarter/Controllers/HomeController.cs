using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KegStarter.Models;

namespace KegStarter.Controllers
{
     public class HomeController : Controller
    {
        [AllowAnonymous]
         public ActionResult Index()
        {
            return View();
        }

        public ActionResult BeerHistories()
        {
            ViewBag.Message = "BeerHistories";

            return View();
        }

        public ActionResult Vote()
        {

            VoteDataModel model = new VoteDataModel("NextBeer", Request.PhysicalApplicationPath + "App_Data\\");
            model.Open();
            ViewData[model.ViewDataName] = model;
            

            //VoteDataModel model = new VoteDataModel("Pet", Request.PhysicalApplicationPath + "App_Data\\");
            //model.Open();
            //ViewData[model.ViewDataName] = model;
            //model = new VoteDataModel("LongQuestionsAndAnswers", Request.PhysicalApplicationPath + "App_Data\\");
            //model.Open();
            //ViewData[model.ViewDataName] = model;

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}