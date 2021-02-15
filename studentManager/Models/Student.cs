using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentManager.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required (ErrorMessage ="Enter cin")]
        public string cin { get; set; }
        [Required(ErrorMessage = "Enter The First Name")]
        public  string firstName { get; set; }
        [Required(ErrorMessage = "Enter The Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Enter The Address")]
        public  string Address { get; set; }
    }
}