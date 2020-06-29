using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите должность")]
        public string Speciality { get; set; }
    }
}
