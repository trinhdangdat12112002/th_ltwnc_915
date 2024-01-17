using Ex_Author.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ex_Author.Models;

namespace Ex_Author.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AuthorRepository authorRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            authorRepository = new AuthorRepository();
        }

        public IActionResult Index()
        {
            List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");

            if (authors == null)
            {
                authors = authorRepository.GetAuthors();
                HttpContext.Session.SetObject("Authors", authors);
            }
            else
            {
                authorRepository.authors = authors;
                authors = authorRepository.GetAuthors();
                HttpContext.Session.SetObject("Authors", authors);
            }
            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Route("Home/GetAuthor/{authorID:int}")]
        public IActionResult GetAuthor(int authorID)
        {
            List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");
            authorRepository.authors = authors;
            var data = authorRepository.GetAuthor(authorID);
            return View("GetAuthor", data);
        }

        [HttpGet]
        [Route("Home/UpdateAuthor/{authorID:int}")]
        public IActionResult UpdateAuthor(int authorID)
        {
            List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");

            authorRepository.authors = authors;
            var data = authorRepository.GetAuthor(authorID);
            return View("UpdateAuthor", data);
        }

        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");
                authorRepository.authors = authors;
                authorRepository.UpdateAuthor(author);
                authors = authorRepository.authors;
                HttpContext.Session.SetObject("Authors", authors);

                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        [Route("Home/DeleteAuthor/{authorID:int}")]
        public IActionResult DeleteAuthor(int authorID)
        {
            /*List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");

            authorRepository.authors = authors;
            var data = authorRepository.GetAuthor(authorID);
            return View("DeleteAuthor", data);*/


            List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");
            authorRepository.authors = authors;
            authorRepository.DeleteAuthor(authorID);
            authors = authorRepository.authors;
            HttpContext.Session.SetObject("Authors", authors);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAuthor(Author author)
        {
            List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");
            authorRepository.authors = authors;
            authorRepository.DeleteAuthor(author.Id);
            authors = authorRepository.authors;
            HttpContext.Session.SetObject("Authors", authors);

            return RedirectToAction("Index");

            /*            return View(author);*/
        }

        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View("CreateAuthor");
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                List<Author> authors = HttpContext.Session.GetObject<List<Author>>("Authors");
                authorRepository.authors = authors;

                if (authorRepository.CreateAuthor(author))
                {
                    authors = authorRepository.authors;
                    HttpContext.Session.SetObject("Authors", authors);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tác giả đã tồn tại.");
                }
            }
            return View(author);

        }

        public IActionResult Bai13() {
            return View("Bai13");
        }
    }
}