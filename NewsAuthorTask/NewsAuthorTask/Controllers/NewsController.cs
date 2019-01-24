using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsAuthorTask.Models;
using System.IO;
namespace NewsAuthorTask.Controllers
{
    public class NewsController : Controller
    {

        private ApplicationDbContext _context;

        public NewsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult EmptyNews()
        {
            return View("EmptyNews");
        }
        public ActionResult editnews(int id)
        {
            var Authornamelist = _context.authors.ToList();
            var news = _context.news.SingleOrDefault(c => c.id == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsAuthorViewModel viewmodel = new NewsAuthorViewModel
            {
                author = Authornamelist,
                news = news
            };

            return View("NewsForm", viewmodel);
        }
        public ActionResult shownews()
        {
            var viewModel = from a in _context.authors
                            join n in _context.news on a.Id equals n.Authorid
                            select new Authornews { author = a, news = n };

            if (!viewModel.Any())
            {
                return RedirectToAction("EmptyNews", "News");
            }
            return View(viewModel);
        }
        public ActionResult AddNews()
        {
            var Authornamelist = _context.authors.ToList();
            NewsAuthorViewModel viewmodel = new NewsAuthorViewModel
            {
                author = Authornamelist
            };

            return View("NewsForm", viewmodel);
        }
        [HttpPost]
        public ActionResult SaveNews(NewsAuthorViewModel viewmodel, HttpPostedFileBase newsimg)
        {


            if (!ModelState.IsValid)
            {


                var Authornamelist = _context.authors.ToList();
                NewsAuthorViewModel viewModel = new NewsAuthorViewModel
                {
                    author = Authornamelist,
                    news = viewmodel.news,

                };

                return View("NewsForm", viewModel);
            }

            if (viewmodel.news.id == null)
            {
                if (newsimg != null && newsimg.ContentLength > 0)
                {
                    string filename = Path.GetFileName(newsimg.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/images/"), filename);
                    newsimg.SaveAs(imgpath);
                    viewmodel.news.newsimg = "~/images/" + newsimg.FileName;
                    _context.news.Add(viewmodel.news);
                }
            }
            else
            {

                var NewsInDb = _context.news.Single(c => c.id == viewmodel.news.id);
                NewsInDb.newstitle = viewmodel.news.newstitle;
                NewsInDb.newscontent = viewmodel.news.newscontent;
                NewsInDb.Authorid = viewmodel.news.Authorid;
                NewsInDb.creationDate = viewmodel.news.creationDate;
                NewsInDb.publicationDate = viewmodel.news.publicationDate;
                if (newsimg != null && newsimg.ContentLength > 0)
                {
                    string filename = Path.GetFileName(newsimg.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/images/"), filename);
                    newsimg.SaveAs(imgpath);
                    viewmodel.news.newsimg = "~/images/" + newsimg.FileName;
                    NewsInDb.newsimg = viewmodel.news.newsimg;
                }

            }

            _context.SaveChanges();
            return RedirectToAction("shownews");
        }
        public ActionResult deletenews(int id)
        {
            var news = _context.news.SingleOrDefault(c => c.id == id);
            _context.news.Remove(news);
            _context.SaveChanges();
            return RedirectToAction("shownews");

        }
    }
}
