using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uowProject.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public DateTime FoundationDate { get; set; }
        public decimal DeveloperValue { get; set; }
    }
}
