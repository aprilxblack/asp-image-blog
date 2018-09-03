using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Stronka.Models;

namespace Stronka.Controllers
{
    public class HomeController : Controller
    {
        private DbContext db = new DbContext();
        

        public ActionResult Index()
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

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult ViewImage(string image = "")
        {
            int imageId;

            try {
                imageId = int.Parse(image);
            } catch (FormatException) {
                Random r = new Random(DateTime.Now.DayOfYear + DateTime.Now.Year * 400);
                imageId = r.Next(1, 11);
            }

            Image imageObj = db.Images.Find(imageId);

            return View(imageObj);
        }

        public ActionResult SetupImages()
        {
            for (var i = 1; i <= 10; i++)
            {
                db.Images.Add(new Image("/Content/img/" + i + ".jpg"));
            }
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
        
        public ActionResult AddRating()
        {
            int imageId = int.Parse(Request["image"]);
            Image imageObj = db.Images.Find(imageId);

            // Check if rating exists from this ip
            var foundRating = db.Ratings.FirstOrDefault(rat => rat.IP == Request.UserHostAddress );
            if(foundRating != null)
            {
                // remove old rating
                db.Ratings.Remove(foundRating);
            }

            // add rating
            Rating r = new Rating();
            r.Image = imageObj;
            r.IP = Request.UserHostAddress;
            r.Score = int.Parse(Request["score"]);
            db.Ratings.Add(r);

            // save db changes so correct average is calculated
            db.SaveChanges();

            // calculate average
            double ratings = 0;
            int count = 0;

            foreach(Rating rating in imageObj.Ratings)
            {
                ratings += rating.Score;
                count++;
            }

            if(count > 0)
                ratings = ratings / count;

            // save image score
            imageObj.AvgScore = (float)ratings;
            db.SaveChanges();

            return RedirectToAction("ViewImage", new { image = imageId });
        }

        [HttpPost]
        public ActionResult AddComment()
        {
            int imageId = int.Parse(Request["image"]);
            Image imageObj = db.Images.Find(imageId);

            Comment c = new Comment();
            c.Image = imageObj;
            c.Message = Request["message"];
            c.Name = Request["nickname"];
            c.Timestamp = DateTime.Now;

            db.Comments.Add(c);
            db.SaveChanges();


            return RedirectToAction("ViewImage", new { image = imageId });
        }

    }
}