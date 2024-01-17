using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace Ex_Author.Controllers
{
    public class BaiTestController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BaiTestController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "App_Data", "Bai16");
            var dir = new DirectoryInfo(uploadsFolder);

            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();

            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return View(items);
        }
    }
}