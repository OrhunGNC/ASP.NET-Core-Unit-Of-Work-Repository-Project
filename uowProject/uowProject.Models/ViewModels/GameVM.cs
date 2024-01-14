using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uowProject.Models.ViewModels
{
    public class GameVM
    {
        public Game Game { get; set; }
        public IEnumerable<SelectListItem> DeveloperList { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
