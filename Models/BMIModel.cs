using System.ComponentModel.DataAnnotations;
namespace Ex_Author.Models
{
    public class BMIModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Chiều cao")]
        [Range(0.1, 2.5, ErrorMessage = "Chiều cao phải nằm trong khoảng từ 0.1m đến 2.5m")]
        public double height { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Cân nặng")]
        [Range(0.1, 250, ErrorMessage = "Cân nặng phải nằm trong khoảng từ 0.1kg đến 250kg")]
        public  double weight { get; set; }
        public double bmi()
        {
            return weight / (height * height);
        }
    }
}
