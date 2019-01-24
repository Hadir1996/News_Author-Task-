using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsAuthorTask.Models;
namespace NewsAuthorTask.Controllers
{
    public class AuthorsController : Controller
    {

        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       public ActionResult Home()
        {
            return View();
        }
        public ActionResult showauthors()
        {
            
            var viewModel = from c in _context.authors
                          select c;
              
          if (!viewModel.Any())
            {
                return View("EmptyAuthor");
            }
            return View(viewModel);
        }
        public ActionResult editauthor(int id)
        {
            var author = _context.authors.SingleOrDefault(c => c.Id == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            var authormodel = new Author();
            authormodel = author;
            return View("AddAuthorForm", authormodel);
        }
        public ActionResult createauthor()
        {
            
            return View("AddAuthorForm");
        }
        public ActionResult deleteauthor(int id)
        {
            var author = _context.authors.SingleOrDefault(c => c.Id == id);
            _context.authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("showauthors");
        }
        [HttpPost]
        public ActionResult saveauthor(Author author)
        {
            if (author.Id == 0)
            {
                _context.authors.Add(author);
            }
            else
            {
                var authorindb = _context.authors.Single(c => c.Id == author.Id);
                authorindb.Name = author.Name;  
                authorindb.Email = author.Email;
            }
                _context.SaveChanges();
                return RedirectToAction("showauthors", "Authors");
            
        }
       
      

       
    }
}
