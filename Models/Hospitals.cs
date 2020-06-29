using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Hospitals
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Введите телефон")]
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +xxxx-xxx-xxxx")]
        public string Phones { get; set; }
    }
}
