using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Job
    {
        [Key]
        public int id { get; set; }
        public string JobTitle { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}