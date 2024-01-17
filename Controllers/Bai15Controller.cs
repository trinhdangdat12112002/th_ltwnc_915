using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Ex_Author.Controllers
{
    public class Bai15Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string hoTen, string ngaySinh, string gioiTinh)
        {
            var xmlData = new XElement("UserData",
                            new XElement("HoTen", hoTen),
                            new XElement("NgaySinh", ngaySinh),
                            new XElement("GioiTinh", gioiTinh));

            var fileName = $"UserData_{DateTime.Now:yyyyMMddHHmmss}.xml";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Bai15", fileName);
            xmlData.Save(filePath);

            return Content(xmlData.ToString(), "application/xml");
        }

        [HttpGet]
        public IActionResult Xuly2(string hoTen, string ngaySinh, string gioiTinh)
        {
            var xmlData = new XElement("UserData",
                            new XElement("HoTen", hoTen),
                            new XElement("NgaySinh", ngaySinh),
                            new XElement("GioiTinh", gioiTinh));

            return Content(xmlData.ToString(), "application/xml");
        }
    }
}
