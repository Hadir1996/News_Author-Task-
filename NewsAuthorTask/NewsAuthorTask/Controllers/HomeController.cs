using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsAuthorTask.Models;
namespace NewsAuthorTask.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult ShowNews()
        {
            var query = from a in _context.authors
                        join n in _context.news on a.Id equals n.Authorid
                        select new Authornews { author = a, news = n };
           
            if (!query.Any())
            {
                return RedirectToAction("EmptyNews","News");
            }
            return View(query);
        }
        public ActionResult ShowDetails(int id )
        {
              var query=    from a in _context.authors
                            join n in _context.news on a.Id equals n.Authorid
                            where n.id == id
                            select new Authornews { author = a, news = n };
              
            return View(query);
        }
       

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}