using Ex_Author.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex_Author.Controllers
{
    public class BMIController : Controller
    {
        private readonly ILogger<BMIController> _logger;

        public BMIController(ILogger<BMIController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BMIModel model)
        {
            if (ModelState.IsValid)
            {
                double bmi = model.bmi();
                if (bmi < 18.5)
                {
                    ViewData["Result"] = $"BMI của bạn là {bmi:F2} bạn ở mức dưới chuẩn";
                }
                else if (bmi < 25 )
                {
                    ViewData["Result"] = $"BMI của bạn là {bmi:F2} bạn ở mức chuẩn";
                }
                else if (bmi < 30)
                {
                    ViewData["Result"] = $"BMI của bạn là {bmi:F2} bạn ở mức thừa cân";
                }
                else if (bmi < 40)
                {
                    ViewData["Result"] = $"BMI của bạn là {bmi:F2} bạn ở mức béo cần giảm cân";
                }
                else 
                {
                    ViewData["Result"] = $"BMI của bạn là {bmi:F2} bạn ở mức rất béo cần giảm cân";
                }
            }   
            return View(model);
        }
    }
}
