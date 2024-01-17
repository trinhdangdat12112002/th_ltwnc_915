using Ex_Author.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace Ex_Author.Controllers
{
    public class Bai16Controller : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Bai16Controller(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int i=0)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            var file = Request.Form.Files[0];
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data", "Bai16", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return RedirectToAction("Download");
        }

        [HttpGet]
        public IActionResult Download()
        {
            var uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data", "Bai16");
            var dir = new DirectoryInfo(uploadsFolder);

            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();

            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return View(items);
        }
        [HttpGet]
        public FileResult Downloads(string fileName)
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data", "Bai16", fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);

        }
    }
}
