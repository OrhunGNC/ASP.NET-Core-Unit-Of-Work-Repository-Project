using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uowProject.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Category { get; set; }
        public string GamePriceBefore { get; set; }
        public string GamePriceAfter { get; set; }
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        [ForeignKey("DeveloperId")]
        public Developer Developer { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
